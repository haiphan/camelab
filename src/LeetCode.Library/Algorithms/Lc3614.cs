namespace LeetCode.Library.Algorithms;

public class Lc3614Solution {
    public char ProcessStr(string s, long k) {
        // Forward pass: track lengths exactly, saturating only at long overflow.
        // Clamping at 2*(k+1) was wrong: '%' backward needs the exact currLen to compute
        // currLen-1-idx; premature clamping gives the wrong reflected index.
        long[] lengths = new long[s.Length + 1];
        for (int i = 0; i < s.Length; i++) {
            long prev = lengths[i];
            lengths[i + 1] = s[i] switch {
                '*' => prev > 0 ? prev - 1 : 0,
                '#' => prev > long.MaxValue / 2 ? long.MaxValue : prev * 2,
                '%' => prev,
                _   => prev < long.MaxValue ? prev + 1 : long.MaxValue,
            };
        }

        if (lengths[s.Length] <= k) return '.';

        // Backward pass: undo each operation to find what character sits at index k
        long idx = k;
        for (int i = s.Length - 1; i >= 0; i--) {
            long prevLen = lengths[i];
            long currLen = lengths[i + 1];
            switch (s[i]) {
                case '*': break;                          // idx unchanged; last char was removed
                case '#': idx %= prevLen; break;          // idx maps into the first copy
                case '%': idx = currLen - 1 - idx; break; // reverse maps idx
                default:
                    if (idx == prevLen) return s[i];      // idx points at the appended char
                    break;
            }
        }

        return '.';
    }
}