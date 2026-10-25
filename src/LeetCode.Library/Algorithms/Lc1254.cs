namespace LeetCode.Library.Algorithms;

public class Lc1254Solution {
    public int ClosedIsland(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

        void Fill(int r, int c) {
            if (r < 0 || r >= m || c < 0 || c >= n || grid[r][c] != 0) return;
            grid[r][c] = 1;
            Fill(r - 1, c);
            Fill(r + 1, c);
            Fill(r, c - 1);
            Fill(r, c + 1);
        }

        // land reachable from the border can never be a closed island, so sink it first
        for (int i = 0; i < m; i++) {
            Fill(i, 0);
            Fill(i, n - 1);
        }
        for (int j = 0; j < n; j++) {
            Fill(0, j);
            Fill(m - 1, j);
        }

        int count = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) {
                    count++;
                    Fill(i, j);
                }
            }
        }
        return count;
    }
}