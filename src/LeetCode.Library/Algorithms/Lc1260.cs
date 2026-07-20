namespace LeetCode.Library.Algorithms;

public class Lc1260Solution {
    public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;
        int total = m * n;
        k %= total;

        IList<IList<int>> result = new List<IList<int>>(m);
        for (int i = 0; i < m; i++) {
            List<int> row = new List<int>(n);
            for (int j = 0; j < n; j++) {
                int sourceIndex = (i * n + j - k + total) % total;
                row.Add(grid[sourceIndex / n][sourceIndex % n]);
            }
            result.Add(row);
        }

        return result;
    }
}