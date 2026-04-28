namespace LeetCode.Library.Algorithms;

public class Lc2033Solution {
    public int MinOperations(int[][] grid, int x) {
        int m = grid.Length, n = grid[0].Length;
        if (m == 1 && n == 1) {
            return 0;
        }
        int total = m * n;
        int[] counts = new int[10001];
        int r = grid[0][0] % x;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] % x != r) {
                    return -1;
                }
                counts[grid[i][j] / x]++;
            }
        }
        int seen = 0;
        int target = total / 2;
        int median = 0;
        for (; median < counts.Length; median++) {
            seen += counts[median];
            if (seen > target) {
                break;
            }
        }
        int ans = 0;
        for (int num = 0; num < counts.Length; num++) {
            ans += Math.Abs(num - median) * counts[num];
        }
        return ans;
    }
}