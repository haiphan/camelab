namespace LeetCode.Library.Algorithms;

public class Lc3212Solution {
    private static int IsZero01(int x) {
        // 1 when x == 0, otherwise 0, without branching.
        return 1 ^ (((x | -x) >> 31) & 1);
    }

    public int NumberOfSubmatrices(char[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int cnt = 0;
        int[] xRow = new int[n];
        int[] yRow = new int[n];
        for (int i = 0; i < m; i++) {
            int x = 0, y = 0;
            for (int j = 0; j < n; j++) {
                int d = grid[i][j] - 'X'; // X->0, Y->1, .->-42
                xRow[j] += IsZero01(d);
                yRow[j] += IsZero01(d - 1);
                x += xRow[j];
                y += yRow[j];
                if (x > 0 && x == y) {
                    cnt++;
                }
            }
        }
        return cnt;
    }
}