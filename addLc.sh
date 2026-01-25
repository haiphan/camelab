#!/bin/bash

# Check if arguments are provided
if [ $# -lt 2 ]; then
    echo "Usage: ./addLc.sh <ID> <FunctionName>"
    echo "Example: ./addLc.sh 1234 MyAlgorithm"
    exit 1
fi

ID=$1
NAME=$2

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

# Generate Algorithm File
if [ ! -f "$ALGO_FILE" ]; then
    sed -e "s/{ID}/$ID/g" -e "s/{NAME}/$NAME/g" "$TEMPLATE_DIR/algorithm.txt" > "$ALGO_FILE"
    echo "Created: $ALGO_FILE"
else
    echo "Skip: $ALGO_FILE already exists."
fi

# Generate Test File
if [ ! -f "$TEST_FILE" ]; then
    sed -e "s/{ID}/$ID/g" -e "s/{NAME}/$NAME/g" "$TEMPLATE_DIR/test.txt" > "$TEST_FILE"
    echo "Created: $TEST_FILE"
else
    echo "Skip: $TEST_FILE already exists."
fi

echo "Done! Happy coding."