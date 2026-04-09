#!/usr/bin/env python3
import json
import re
import sys


def split_params(params: str) -> list[str]:
    parts: list[str] = []
    token: list[str] = []
    depth = 0
    for ch in params:
        if ch == "," and depth == 0:
            part = "".join(token).strip()
            if part:
                parts.append(part)
            token = []
            continue
        if ch == "<":
            depth += 1
        elif ch == ">":
            depth = max(0, depth - 1)
        token.append(ch)

    tail = "".join(token).strip()
    if tail:
        parts.append(tail)
    return parts


def extract_signature_from_stdin() -> str:
    try:
        data = json.load(sys.stdin)
    except Exception:
        return ""

    question = ((data.get("data") or {}).get("question") or {})
    snippets = question.get("codeSnippets") or []

    code = ""
    for snippet in snippets:
        if (snippet or {}).get("langSlug") == "csharp":
            code = (snippet or {}).get("code") or ""
            break

    if not code:
        return ""

    for line in code.splitlines():
        stripped = line.strip()
        if stripped.startswith("public ") and "(" in stripped and ")" in stripped:
            return re.sub(r"\s*\{\s*$", "", stripped)

    return ""


def extract_metadata(signature: str) -> dict[str, str]:
    signature = signature.strip()
    match = re.match(
        r"^(?:public|private|protected|internal)\s+(?:static\s+|virtual\s+|override\s+|sealed\s+|new\s+|async\s+|extern\s+|unsafe\s+|partial\s+)*(.+?)\s+([A-Za-z_][A-Za-z0-9_]*)\s*\((.*)\)\s*$",
        signature,
    )
    if not match:
        return {
            "return_type": "",
            "arg_decls": "",
            "arg_names": "",
            "arg_types": "",
        }

    return_type = match.group(1).strip()
    params = match.group(3).strip()
    if not params:
        return {
            "return_type": return_type,
            "arg_decls": "",
            "arg_names": "",
            "arg_types": "",
        }

    arg_decls: list[str] = []
    arg_names: list[str] = []
    arg_types: list[str] = []

    for part in split_params(params):
        left = part.split("=")[0].strip()
        if not left:
            continue
        tokens = left.split()
        if not tokens:
            continue

        name = tokens[-1].lstrip("@")
        type_tokens = tokens[:-1]
        while type_tokens and type_tokens[0] in {"ref", "out", "in", "params", "this"}:
            type_tokens = type_tokens[1:]
        type_name = " ".join(type_tokens).strip()
        if not type_name or not name:
            continue

        arg_decls.append(f"{type_name} {name}")
        arg_names.append(name)
        arg_types.append(type_name)

    return {
        "return_type": return_type,
        "arg_decls": ", ".join(arg_decls),
        "arg_names": ", ".join(arg_names),
        "arg_types": ", ".join(arg_types),
    }


def build_data_rows(theory_types_csv: str) -> str:
    theory_types = [t.strip() for t in theory_types_csv.split(",") if t.strip()]
    primitive_defaults = {
        "bool": "false",
        "byte": "0",
        "sbyte": "0",
        "short": "0",
        "ushort": "0",
        "int": "0",
        "uint": "0u",
        "long": "0L",
        "ulong": "0UL",
        "float": "0f",
        "double": "0d",
        "decimal": "0m",
        "char": "'a'",
        "string": '""',
    }

    if not theory_types:
        return "        // Add test cases"

    values: list[str] = []
    for t in theory_types:
        normalized = " ".join(t.split())
        if normalized not in primitive_defaults:
            return "        // Add test cases"
        values.append(primitive_defaults[normalized])

    return f"        {{ {', '.join(values)} }},"


def render_test_template(
    template_path: str,
    output_path: str,
    id_value: str,
    name: str,
    theory_types: str,
    test_params: str,
    method_call: str,
    data_rows: str,
) -> None:
    replacements = {
        "{ID}": id_value,
        "{NAME}": name,
        "{THEORY_TYPES}": theory_types,
        "{TEST_PARAMS}": test_params,
        "{METHOD_CALL}": method_call,
        "{DATA_ROWS}": data_rows,
    }

    with open(template_path, "r", encoding="utf-8") as f:
        content = f.read()

    for key, value in replacements.items():
        content = content.replace(key, value)

    with open(output_path, "w", encoding="utf-8") as f:
        f.write(content)


def main() -> int:
    command = sys.argv[1] if len(sys.argv) > 1 else "signature"

    if command == "signature":
        print(extract_signature_from_stdin())
        return 0

    if command == "metadata":
        signature = sys.argv[2] if len(sys.argv) > 2 else ""
        metadata = extract_metadata(signature)
        print(f"return_type={metadata['return_type']}")
        print(f"arg_decls={metadata['arg_decls']}")
        print(f"arg_names={metadata['arg_names']}")
        print(f"arg_types={metadata['arg_types']}")
        return 0

    if command == "data-rows":
        theory_types = sys.argv[2] if len(sys.argv) > 2 else ""
        print(build_data_rows(theory_types))
        return 0

    if command == "render-test-template":
        if len(sys.argv) != 10:
            return 1
        render_test_template(
            template_path=sys.argv[2],
            output_path=sys.argv[3],
            id_value=sys.argv[4],
            name=sys.argv[5],
            theory_types=sys.argv[6],
            test_params=sys.argv[7],
            method_call=sys.argv[8],
            data_rows=sys.argv[9],
        )
        return 0

    return 1


if __name__ == "__main__":
    raise SystemExit(main())
