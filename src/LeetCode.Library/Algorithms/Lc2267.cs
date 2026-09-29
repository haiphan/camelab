namespace LeetCode.Library.Algorithms;

public class Lc2267Solution {
    public bool HasValidPath(char[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

        // Path length m+n-1 must be even, and it must start with '(' and end with ')'
        if ((m + n - 1) % 2 != 0 || grid[0][0] == ')' || grid[m - 1][n - 1] == '(') return false;

        // Balance can never exceed half the path length. m,n <= 100 means maxBalance <= 99,
        // so the set of achievable balances at a cell fits in a 128-bit mask (two ulongs).
        int maxBalance = (m + n - 1) / 2;
        ulong maskLo = maxBalance >= 63 ? ulong.MaxValue : (1UL << (maxBalance + 1)) - 1;
        int hiBits = maxBalance - 63;
        ulong maskHi = hiBits <= 0 ? 0UL : (1UL << hiBits) - 1;

        // Only the row above and the already-computed left cell are ever read,
        // so a single rolling row (updated in place) replaces the full m*n grid.
        var lo = new ulong[n];
        var hi = new ulong[n];
        lo[0] = 1UL << 1; // balance 1 after the opening '('

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 && j == 0) continue;

                ulong inLo = 0, inHi = 0;
                if (i > 0) { inLo |= lo[j]; inHi |= hi[j]; }
                if (j > 0) { inLo |= lo[j - 1]; inHi |= hi[j - 1]; }

                ulong outLo, outHi;
                // 1 for '(', 0 for ')' — blend both shift directions without branching
                ulong open = (ulong)(')' - grid[i][j]);
                ulong leftLo = inLo << 1;
                ulong leftHi = (inHi << 1) | (inLo >> 63);
                ulong rightLo = (inLo >> 1) | (inHi << 63);
                ulong rightHi = inHi >> 1;
                outLo = open * leftLo + (1 - open) * rightLo;
                outHi = open * leftHi + (1 - open) * rightHi;

                lo[j] = outLo & maskLo;
                hi[j] = outHi & maskHi;
            }
        }

        return (lo[n - 1] & 1UL) != 0;
    }
}