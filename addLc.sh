#!/bin/bash

# Check if arguments are provided
if [ $# -lt 2 ]; then
    echo "Usage: ./addLc.sh <ID> <FunctionName> [LeetCodeProblemUrl]"
    echo "   or: ./addLc.sh <ID> <LeetCodeProblemUrl>"
    echo "Example: ./addLc.sh 1 TwoSum https://leetcode.com/problems/two-sum/"
    echo "Example: ./addLc.sh 1 https://leetcode.com/problems/two-sum/"
    exit 1
fi

ID=$1
ARG2=$2
ARG3=$3
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PARSER_SCRIPT="$SCRIPT_DIR/scripts/extract_lc_csharp_signature.py"

extract_slug_from_url() {
    local problem_url="$1"
    printf "%s" "$problem_url" | sed -E 's#^https?://(www\.)?leetcode\.com/problems/([^/]+)/?.*$#\2#'
}

slug_to_pascal_case() {
    local slug="$1"
    printf "%s" "$slug" | awk -F- '{
        for (i = 1; i <= NF; i++) {
            if (length($i) == 0) {
                continue
            }
            printf toupper(substr($i, 1, 1)) tolower(substr($i, 2))
        }
        print ""
    }'
}

if [[ "$ARG2" =~ ^https?://(www\.)?leetcode\.com/problems/[^/]+/?$ ]]; then
    NAME=""
    LEETCODE_URL="$ARG2"
else
    NAME="$ARG2"
    LEETCODE_URL="$ARG3"
fi

fetch_signature_from_leetcode() {
    local problem_url="$1"
    local slug
    local payload
    local response

    if [ -z "$problem_url" ]; then
        return 0
    fi

    slug=$(extract_slug_from_url "$problem_url")
    if [ -z "$slug" ] || [ "$slug" = "$problem_url" ]; then
        echo "Warning: Could not parse LeetCode slug from URL: $problem_url" >&2
        return 0
    fi

    if ! command -v curl >/dev/null 2>&1; then
        echo "Warning: curl is required to fetch LeetCode signature." >&2
        return 0
    fi

    if ! command -v python3 >/dev/null 2>&1; then
        echo "Warning: python3 is required to parse LeetCode response." >&2
        return 0
    fi

    if [ ! -f "$PARSER_SCRIPT" ]; then
        echo "Warning: parser script not found: $PARSER_SCRIPT" >&2
        return 0
    fi

    payload=$(printf '{"query":"query questionData($titleSlug: String!) { question(titleSlug: $titleSlug) { codeSnippets { langSlug code } } }","variables":{"titleSlug":"%s"}}' "$slug")
    echo "Fetch with payload: $payload" >&2
    response=$(curl -sS "https://leetcode.com/graphql" \
        -H "Content-Type: application/json" \
        -H "Referer: https://leetcode.com/problems/$slug/" \
        --data "$payload") || {
        echo "Warning: Failed to fetch LeetCode metadata for slug '$slug'." >&2
        return 0
    }

    printf "%s" "$response" | python3 "$PARSER_SCRIPT" signature
}

extract_test_metadata_from_signature() {
    local signature="$1"

    if [ -z "$signature" ]; then
        return 0
    fi

    python3 "$PARSER_SCRIPT" metadata "$signature"
}

escape_sed_replacement() {
    printf "%s" "$1" | sed -e 's/[\/&]/\\&/g'
}

build_data_rows() {
    local theory_types="$1"
    python3 "$PARSER_SCRIPT" data-rows "$theory_types"
}

# Define paths
SRC_DIR="src/LeetCode.Library/Algorithms"
TEST_DIR="tests/LeetCode.Tests"
TEMPLATE_DIR="templates"

# Create directories if they don't exist
mkdir -p "$SRC_DIR"
mkdir -p "$TEST_DIR"

# File names
ALGO_FILE="$SRC_DIR/Lc$ID.cs"
TEST_FILE="$TEST_DIR/Lc${ID}Tests.cs"
LC_SIGNATURE=$(fetch_signature_from_leetcode "$LEETCODE_URL")
RETURN_TYPE="int"
METHOD_ARGS=""
TEST_PARAMS="int expected"
THEORY_TYPES="int"
METHOD_CALL="solution.${NAME}(/* args */)"
DATA_ROWS="        { 0 },"

if [ -z "$NAME" ] && [ -n "$LC_SIGNATURE" ]; then
    NAME=$(printf "%s" "$LC_SIGNATURE" | sed -E 's/.* ([A-Za-z_][A-Za-z0-9_]*)\s*\(.*/\1/')
fi

if [ -z "$NAME" ] && [ -n "$LEETCODE_URL" ]; then
    SLUG=$(extract_slug_from_url "$LEETCODE_URL")
    if [ -n "$SLUG" ] && [ "$SLUG" != "$LEETCODE_URL" ]; then
        NAME=$(slug_to_pascal_case "$SLUG")
        if [ -n "$NAME" ]; then
            echo "Info: Using function name '$NAME' derived from URL slug."
        fi
    fi
fi

if [ -z "$NAME" ]; then
    echo "Error: Function name is required. Provide it explicitly or pass a valid LeetCode URL." >&2
    exit 1
fi

if [ -n "$LC_SIGNATURE" ]; then
    METADATA=$(extract_test_metadata_from_signature "$LC_SIGNATURE")
    RETURN_TYPE=$(printf "%s\n" "$METADATA" | sed -n 's/^return_type=//p')
    ARG_DECLS=$(printf "%s\n" "$METADATA" | sed -n 's/^arg_decls=//p')
    ARG_TYPES=$(printf "%s\n" "$METADATA" | sed -n 's/^arg_types=//p')
    METHOD_ARGS=$(printf "%s\n" "$METADATA" | sed -n 's/^arg_names=//p')

    if [ -n "$ARG_DECLS" ]; then
        TEST_PARAMS="$ARG_DECLS, $RETURN_TYPE expected"
    else
        TEST_PARAMS="$RETURN_TYPE expected"
    fi

    if [ -n "$ARG_TYPES" ]; then
        THEORY_TYPES="$ARG_TYPES, $RETURN_TYPE"
    else
        THEORY_TYPES="$RETURN_TYPE"
    fi

    METHOD_CALL="solution.${NAME}(${METHOD_ARGS})"
else
    TEST_PARAMS="int expected"
    THEORY_TYPES="int"
    METHOD_CALL="solution.${NAME}(/* args */)"
fi

DATA_ROWS=$(build_data_rows "$THEORY_TYPES")

# Generate Algorithm File
if [ ! -f "$ALGO_FILE" ]; then
    sed -e "s/{ID}/$ID/g" -e "s/{NAME}/$NAME/g" "$TEMPLATE_DIR/algorithm.txt" > "$ALGO_FILE"

    if [ -n "$LC_SIGNATURE" ]; then
        ESCAPED_SIGNATURE=$(escape_sed_replacement "$LC_SIGNATURE")
        sed -i '' -E "s/public void ${NAME}\(\)/${ESCAPED_SIGNATURE}/" "$ALGO_FILE"
        echo "Injected LeetCode signature into: $ALGO_FILE"
    fi

    echo "Created: $ALGO_FILE"
else
    echo "Skip: $ALGO_FILE already exists."
fi

# Generate Test File
if [ ! -f "$TEST_FILE" ]; then
    python3 "$PARSER_SCRIPT" render-test-template "$TEMPLATE_DIR/test.txt" "$TEST_FILE" "$ID" "$NAME" "$THEORY_TYPES" "$TEST_PARAMS" "$METHOD_CALL" "$DATA_ROWS"
    echo "Created: $TEST_FILE"
else
    echo "Skip: $TEST_FILE already exists."
fi

echo "Done! Happy coding."