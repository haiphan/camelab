namespace LeetCode.Library.Algorithms;

public class Lc3614Solution {
    public char ProcessStr(string s, long k) {
        // Forward pass: compute only the final length (O(1) space).
        // Problem guarantees final length <= 1e15 < long.MaxValue, so no overflow.
        long len = 0;
        foreach (char c in s) {
            len = c switch {
                '*' => len > 0 ? len - 1 : 0,
                '#' => len * 2,
                '%' => len,
                _   => len + 1,
            };
        }

        if (len <= k) return '.';

        // Backward pass: invert each operation to recover prevLen from currLen,
        // then update idx. No lengths[] array needed.
        long idx = k;
        long currLen = len;
        for (int i = s.Length - 1; i >= 0; i--) {
            char c = s[i];
            long prevLen;
            switch (c) {
                case '*':
                    prevLen = currLen + 1;
                    break;
                case '#':
                    prevLen = currLen >> 1;
                    idx %= prevLen;
                    break;
                case '%':
                    prevLen = currLen;
                    idx = currLen - 1 - idx;
                    break;
                default:
                    prevLen = currLen - 1;
                    if (idx == prevLen) return c;
                    break;
            }
            currLen = prevLen;
        }

        return '.';
    }
}