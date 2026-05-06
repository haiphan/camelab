namespace LeetCode.Library.Algorithms;

public class Lc1861Solution {
    public char[][] RotateTheBox(char[][] boxGrid) {
        int m = boxGrid.Length;
        int n = boxGrid[0].Length;

        char[][] rotatedGrid = new char[n][];
        for (int col = 0; col < n; col++) {
            rotatedGrid[col] = new char[m];
            for (int row = 0; row < m; row++) {
                rotatedGrid[col][row] = '.';
            }
        }

        for (int row = 0; row < m; row++) {
            int emptyCol = n - 1;
            for (int col = n - 1; col >= 0; col--) {
                if (boxGrid[row][col] == '*') {
                    rotatedGrid[col][m - 1 - row] = '*';
                    emptyCol = col - 1;
                } else if (boxGrid[row][col] == '#') {
                    rotatedGrid[emptyCol][m - 1 - row] = '#';
                    emptyCol--;
                }
            }
        }

        return rotatedGrid;
    }
}