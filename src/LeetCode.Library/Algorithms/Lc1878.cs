namespace LeetCode.Library.Algorithms;

public class Lc1878Solution {
    public int[] GetBiggestThree(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;

        // down-right diagonal prefix (↘)
        int[][] diagDR = new int[m + 1][];
        // down-left diagonal prefix (↙), with one extra column for c + 1 access
        int[][] diagDL = new int[m + 1][];
        for (int i = 0; i <= m; i++) {
            diagDR[i] = new int[n + 1];
            diagDL[i] = new int[n + 1];
        }

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                diagDR[i + 1][j + 1] = diagDR[i][j] + grid[i][j];
            }
            for (int j = n - 1; j >= 0; j--) {
                diagDL[i + 1][j] = diagDL[i][j + 1] + grid[i][j];
            }
        }

        int SumDiagDR(int r1, int c1, int r2, int c2) {
            return diagDR[r2 + 1][c2 + 1] - diagDR[r1][c1];
        }

        int SumDiagDL(int r1, int c1, int r2, int c2) {
            return diagDL[r2 + 1][c2] - diagDL[r1][c1 + 1];
        }

        int RhombusBorderSum(int x, int y, int k) {
            if (k == 0) {
                return grid[x][y];
            }

            int top = grid[x - k][y];
            int right = grid[x][y + k];
            int bottom = grid[x + k][y];
            int left = grid[x][y - k];

            int e1 = SumDiagDR(x - k, y, x, y + k);      // top -> right
            int e2 = SumDiagDL(x, y + k, x + k, y);      // right -> bottom
            int e3 = SumDiagDR(x, y - k, x + k, y);      // left -> bottom
            int e4 = SumDiagDL(x - k, y, x, y - k);      // top -> left

            return e1 + e2 + e3 + e4 - top - right - bottom - left;
        }

        int[] top = [-1, -1, -1];

        void AddTop3(int value) {
            if (value == top[0] || value == top[1] || value == top[2]) {
                return;
            }

            for (int i = 0; i < 3; i++) {
                if (value > top[i]) {
                    for (int j = 2; j > i; j--) {
                        top[j] = top[j - 1];
                    }
                    top[i] = value;
                    break;
                }
            }
        }

        for (int x = 0; x < m; x++) {
            for (int y = 0; y < n; y++) {
                int maxK = Math.Min(Math.Min(x, m - 1 - x), Math.Min(y, n - 1 - y));
                for (int k = 0; k <= maxK; k++) {
                    AddTop3(RhombusBorderSum(x, y, k));
                }
            }
        }

        int len = 0;
        while (len < 3 && top[len] != -1) {
            len++;
        }

        int[] ans = new int[len];
        Array.Copy(top, ans, len);
        return ans;
    }
}