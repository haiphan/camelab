namespace LeetCode.Library.Algorithms;

public class Lc1886Solution {
    public bool FindRotation(int[][] mat, int[][] target) {
        int n = mat.Length;
        void rotateMat()
        {
            // rotate mat 90 degree clockwise
            // transpose, then reverse each row
            for (int i = 0; i < n; i++) {
                for (int j = i + 1; j < n; j++) {
                    int temp = mat[i][j];
                    mat[i][j] = mat[j][i];
                    mat[j][i] = temp;
                }
            }
            for (int i = 0; i < n; i++) {
                Array.Reverse(mat[i]);
            }
        }
        bool IsSame(int[][] a, int[][] b)
        {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (a[i][j] != b[i][j]) return false;
                }
            }
            return true;
        }
        for (int i = 0; i < 4; i++) {
            if (IsSame(mat, target)) return true;
            rotateMat();
        }
        return false;
    }
}