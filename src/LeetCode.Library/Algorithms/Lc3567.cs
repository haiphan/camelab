namespace LeetCode.Library.Algorithms;

public class Lc3567Solution {
    public int[][] MinAbsDiff(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;
        int[][] ans = new int[m - k + 1][];
        if (k == 1) {
            for (int i = 0; i < m; i++) {
                ans[i] = new int[n - k + 1];
            }
            return ans;
        }
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
                if (arr[0] == arr[k2 - 1]) {
                    ans[i][j] = 0; // all elements are the same, so the minimum difference is 0
                    continue;
                }
                int minDiff = int.MaxValue;
                for (int x = 1; x < k2; x++)
                {
                    if (arr[x] == arr[x - 1]) continue; // skip duplicates to avoid unnecessary comparisons
                    minDiff = Math.Min(minDiff, Math.Abs(arr[x] - arr[x - 1]));
                }
                ans[i][j] = minDiff;
            }
        }
        return ans;
    }
}