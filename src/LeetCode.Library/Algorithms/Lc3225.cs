namespace LeetCode.Library.Algorithms;

public class Lc3225Solution {
    public long MaximumScore(int[][] grid) {
        int n = grid.Length;
        if (n == 1) {
            return 0;
        }
        long[][] col = new long[n][];
        for (int c = 0; c < n; c++) {
            col[c] = new long[n + 1];
            for (int r = 0; r < n; r++) {
                col[c][r + 1] = col[c][r] + grid[r][c];
            }
        }

        long[] prevPick = new long[n + 1];
        long[] prevSkip = new long[n + 1];

        for (int c = 1; c < n; c++) {
            long[] currPick = new long[n + 1];
            long[] currSkip = new long[n + 1];

            for (int cur = 0; cur <= n; cur++) {
                for (int prev = 0; prev <= n; prev++) {
                    if (cur > prev) {
                        long gain = col[c - 1][cur] - col[c - 1][prev];
                        long score = prevSkip[prev] + gain;
                        currPick[cur] = Math.Max(currPick[cur], score);
                        currSkip[cur] = Math.Max(currSkip[cur], score);
                    } else {
                        long gain = col[c][prev] - col[c][cur];
                        currPick[cur] = Math.Max(currPick[cur], prevPick[prev] + gain);
                        currSkip[cur] = Math.Max(currSkip[cur], prevPick[prev]);
                    }
                }
            }

            prevPick = currPick;
            prevSkip = currSkip;
        }

        long ans = 0;
        for (int i = 0; i <= n; i++) {
            ans = Math.Max(ans, prevPick[i]);
        }

        return ans;
    }
}