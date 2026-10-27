namespace LeetCode.Library.Algorithms;

public class Lc3963Solution {
    public string[] CreateGrid(int m, int n) {
        string[] grid = new string[m];
        for (int i = 0; i < m; i++) {
            char[] row = new char[n];
            if (i == 0)
            {
                for (int j = 0; j < n; j++) {
                    row[j] = '.';
                }
            } else
            {
                for (int j = 0; j < n - 1; j++) {
                    row[j] = '#';
                }
                row[n - 1] = '.';
            }
            grid[i] = new string(row);
        }
        return grid;
    }

    // Counts monotonic (right/down only) paths from (0,0) to (m-1,n-1) avoiding '#' cells.
    public long CountPaths(string[] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        long[] dp = new long[n];
        dp[0] = grid[0][0] == '#' ? 0 : 1;
        for (int j = 1; j < n; j++) {
            dp[j] = grid[0][j] == '#' ? 0 : dp[j - 1];
        }

        for (int i = 1; i < m; i++) {
            dp[0] = grid[i][0] == '#' ? 0 : dp[0];
            for (int j = 1; j < n; j++) {
                dp[j] = grid[i][j] == '#' ? 0 : dp[j] + dp[j - 1];
            }
        }

        return dp[n - 1];
    }
}