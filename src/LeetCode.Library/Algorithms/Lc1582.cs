namespace LeetCode.Library.Algorithms;

public class Lc1582Solution {
    public int NumSpecial(int[][] mat) {
        int m = mat.Length, n = mat[0].Length, ans = 0;
        int[] row = new int[m];
        int[] col = new int[n];
        for(int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                row[i] += mat[i][j];
                col[j] += mat[i][j];
            }
        }
        for(int i = 0; i < m; i++) {
            if (row[i] != 1) continue;
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1 && col[j] == 1) {
                    ans++;
                    break;
                }
            }
        }
        return ans;
    }
}