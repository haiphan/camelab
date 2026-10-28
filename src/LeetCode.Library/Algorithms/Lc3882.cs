namespace LeetCode.Library.Algorithms;

public class Lc3882Solution {
    private static int LIM = 1 << 10;
    private static int BUCK = LIM >> 5;
    private static int MASK = (1 << 5) - 1;
    public int MinCost(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[,] dp = new int[n, BUCK];
        dp[0, grid[0][0] >> 5] |= 1 << (grid[0][0] & MASK);
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                int[] prev = new int[BUCK];
                
                if (i > 0) {
                    for (int k = 0; k < BUCK; k++) {
                        prev[k] |= dp[j, k];
                    }
                }
                if (j > 0) {
                    for (int k = 0; k < BUCK; k++) {
                        prev[k] |= dp[j - 1,k];
                    }
                }

                int val = grid[i][j];
                int[] curr = new int[BUCK];
                
                for (int k = 0; k < LIM; k++)
                {
                    if ((prev[k >> 5] & (1 << (k & MASK))) != 0)
                    {
                        curr[(k ^ val) >> 5] |= 1 << ((k ^ val) & MASK);
                    }
                }

                for (int b = 0; b < BUCK; b++)
                {
                    dp[j, b] = curr[b];
                }
            }
        }
        for (int k = 0; k < LIM; k++)
        {
            if ((dp[n - 1, k >> 5] & (1 << (k & MASK))) != 0) {
                return k;
            }
        }
        return 0;
    }
}