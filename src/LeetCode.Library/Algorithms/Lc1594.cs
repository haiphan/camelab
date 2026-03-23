namespace LeetCode.Library.Algorithms;

public class Lc1594Solution {
    public int MaxProductPath(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        long[,,] dp = new long[m, n, 2];
        dp[0, 0, 0] = dp[0, 0, 1] = grid[0][0];
        long mod = 1_000_000_007;
        long p = grid[0][0];
        for (int i = 1; i < n; i++)
        {
            p *= grid[0][i];
            dp[0, i, 0] = p;
            dp[0, i, 1] = p;
        }
        p = grid[0][0];
        for (int i = 1; i < m; i++)
        {
            p *= grid[i][0];
            dp[i, 0, 0] = p;
            dp[i, 0, 1] = p;
            for (int j = 1; j < n; j++)
            {
                int x = grid[i][j];
                long a = dp[i - 1, j, 0] * x;
                long b = dp[i - 1, j, 1] * x;
                long c = dp[i, j - 1, 0] * x;
                long d = dp[i, j - 1, 1] * x;
                dp[i, j, 0] = Math.Min(Math.Min(a, b), Math.Min(c, d));
                dp[i, j, 1] = Math.Max(Math.Max(a, b), Math.Max(c, d));
            }
        }
        long ans = dp[m - 1, n - 1, 1];
        return ans < 0 ? -1 : (int)(ans % mod);
    }
}