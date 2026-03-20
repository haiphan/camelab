namespace LeetCode.Library.Algorithms;

public class Lc3567Solution {
    public int[][] MinAbsDiff(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;
        int[][] ans = new int[m - k + 1][];
        int k2 = k * k;
        for (int i = 0; i < m - k + 1; i++) {
            ans[i] = new int[n - k + 1];
            for (int j = 0; j < n - k + 1; j++) {
                int[] arr = new int[k2];
                int u = 0;
                for (int x = i; x < i + k; x++) {
                    for (int y = j; y < j + k; y++) {
                        arr[u++] = grid[x][y];
                    }
                }
                Array.Sort(arr);
                int minDiff = int.MaxValue;
                for (int x = 1; x < k2; x++)
                {
                    minDiff = Math.Min(minDiff, Math.Abs(arr[x] - arr[x - 1]));
                    if (minDiff == 0) break; // early stop if we find a pair with zero difference
                }
                ans[i][j] = minDiff;
            }
        }
        return ans;
    }
}