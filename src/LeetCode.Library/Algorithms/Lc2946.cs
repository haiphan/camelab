namespace LeetCode.Library.Algorithms;

public class Lc2946Solution {
    public bool AreSimilar(int[][] mat, int k) {
        int m = mat.Length, n = mat[0].Length;
        k %= n;
        if (k == 0) return true;
        for (int i = 0; i < m; i++) {
            int delta = i % 2 == 0 ? k : n - k;
            for (int j = 0; j < n; j++) {
                if (mat[i][j] != mat[i][(j + delta) % n]) return false;
            }
        }
        return true;
    }
}