#!/usr/bin/env python3
import json
import sys


def main() -> int:
    try:
        data = json.load(sys.stdin)
    except Exception:
        return 1

    if not isinstance(data, dict):
        return 1

    if data.get("errors"):
        return 1

    question = ((data.get("data") or {}).get("question"))
    snippets = (question or {}).get("codeSnippets")

    if question is None or not isinstance(snippets, list):
        return 1

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
