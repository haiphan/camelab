namespace LeetCode.Library.Algorithms;

public class Lc498Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        int m = mat.Length, n = mat[0].Length;
        int[] res = new int[m * n];
        int idx = 0;
        for (int d = 0; d < m + n - 1; d++) {
            int odd = d & 1;
            int even = odd ^ 1;

            int rEven = Math.Min(d, m - 1);
            int cEven = d - rEven;
            int cOdd = Math.Min(d, n - 1);
            int rOdd = d - cOdd;

            int r = even * rEven + odd * rOdd;
            int c = even * cEven + odd * cOdd;
            int dr = odd * 2 - 1;
            int dc = -dr;

            while ((uint)r < (uint)m && (uint)c < (uint)n) {
                res[idx++] = mat[r][c];
                r += dr;
                c += dc;
            }
        }
        return res;
    }
}