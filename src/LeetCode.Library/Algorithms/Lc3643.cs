namespace LeetCode.Library.Algorithms;

public class Lc3643Solution {
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k) {
        int top = x;
        int bottom = x + k - 1;
        void SwapRow(int i, int j) {
            for (int c = y; c < y + k; c++) {
                (grid[i][c], grid[j][c]) = (grid[j][c], grid[i][c]);
            }
        }
        while (top < bottom) {
            SwapRow(top, bottom);
            top++;
            bottom--;
        }
        return grid;
    }
}