namespace LeetCode.Library.Algorithms;

public class Lc1914Solution {
    public int[][] RotateGrid(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;
        int layers = Math.Min(m, n) / 2;
        for (int layer = 0; layer < layers; layer++) {
            int top = layer, left = layer, bottom = m - 1 - layer, right = n - 1 - layer;
            int len = 2 * ((bottom - top) + (right - left));
            int start = k % len;
            if (start == 0) {
                continue;
            }

            List<int> elements = new(len);
            // top row
            for (int j = left; j <= right; j++) {
                elements.Add(grid[top][j]);
            }
            // right column
            for (int i = top + 1; i <= bottom; i++) {
                elements.Add(grid[i][right]);
            }
            // bottom row
            for (int j = right - 1; j >= left; j--) {
                elements.Add(grid[bottom][j]);
            }
            // left column
            for (int i = bottom - 1; i > top; i--) {
                elements.Add(grid[i][left]);
            }

            // put back the rotated elements
            int idx = start;
            // top row
            for (int j = left; j <= right; j++) {
                grid[top][j] = elements[idx];
                idx++;
                if (idx == len) {
                    idx = 0;
                }
            }
            // right column
            for (int i = top + 1; i <= bottom; i++)
            {
                grid[i][right] = elements[idx];
                idx++;
                if (idx == len) {
                    idx = 0;
                }
            }
            // bottom row
            for (int j = right - 1; j >= left; j--)
            {
                grid[bottom][j] = elements[idx];
                idx++;
                if (idx == len) {
                    idx = 0;
                }
            }
            // left column
            for (int i = bottom - 1; i > top; i--)
            {
                grid[i][left] = elements[idx];
                idx++;
                if (idx == len) {
                    idx = 0;
                }
            }
        }
        return grid;
    }
}