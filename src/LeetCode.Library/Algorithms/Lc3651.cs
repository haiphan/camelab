namespace LeetCode.Library.Algorithms;

public class Lc3651Solution {
    public int MinCost(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;
        if (k > 0 && grid[0][0] > grid[m-1][n-1]) {
            return 0;
        }
        int BIG = 1600000;
        int maxv = 0;
        foreach (var row in grid) {
            maxv = Math.Max(maxv, row.Max());
        }
        // sufMinF[x] = min cost to reach any cell with value >= x
        int[] sufMinF = new int[maxv + 2];
        sufMinF.AsSpan().Fill(BIG);
        // minF[x] = min cost to reach any cell with value == x in current iteration
        int[] minF = new int[maxv + 1];
        int[] dp = new int[n + 1];
        // iterate k + 1 times because we can increase cell values up to k times
        for (int b = 0; b <= k; b++) {
            for (int i = 0; i <= maxv; i++ ) {
                minF[i] = BIG;
            }
            // reset dp. By default all inf except dp[1]
            for (int i = 0; i <= n; i++) {
                dp[i] = BIG;
            }
            // starting point. We pay negative cost to enter the cell
            dp[1] = -grid[0][0];
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    int x = grid[i][j];
                    dp[j+1] = Math.Min(dp[j]+ x, Math.Min(dp[j+1]+x, sufMinF[x]));
                    // update minF for this cell value
                    minF[x] = Math.Min(minF[x], dp[j+1]);
                }
            }
            bool done = true;
            for (int i = maxv; i >= 0; i--) {
                // update sufMinF
                int minDist = Math.Min(sufMinF[i+1], minF[i]);
                if (minDist < sufMinF[i]) {
                    sufMinF[i] = minDist;
                    done = false;
                }
            }
            // if no update in sufMinF, we can stop early
            if (done) {
                break;
            }
        }
        return dp[n];
    }
}