namespace LeetCode.Library.Algorithms;

public class Lc48Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        // transpose
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }
        // reverse each row
        for (int i = 0; i < n; i++) {
            Array.Reverse(matrix[i]);
        }
    }
}