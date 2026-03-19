namespace LeetCode.Library.Algorithms;

public class Lc3212Solution {
    private static int Eq01(char a, char b) {
        // 1 when equal, 0 otherwise, without branching.
        return (((a ^ b) - 1) >> 31) & 1;
    }

    public int NumberOfSubmatrices(char[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int cnt = 0;
        int[][] prefix = new int[2][];
        int[][] seenX = new int[2][];
        prefix[0] = new int[n + 1];
        prefix[1] = new int[n + 1];
        seenX[0] = new int[n + 1];
        seenX[1] = new int[n + 1];
        for (int i = 0; i < m; i++) {
            int parity = i % 2;
            int prevParity = 1 - parity;
            for (int j = 0; j < n; j++)
            {
                char cell = grid[i][j];
                int isX = Eq01(cell, 'X');
                int isY = Eq01(cell, 'Y');
                prefix[parity][j + 1] = isX - isY + prefix[parity][j] + prefix[prevParity][j + 1] - prefix[prevParity][j];
                seenX[parity][j + 1] = isX + seenX[parity][j] + seenX[prevParity][j + 1] - seenX[prevParity][j];
                int prefixVal = prefix[parity][j + 1];
                int seenVal = seenX[parity][j + 1];
                int isPrefixZero = 1 ^ (((prefixVal | -prefixVal) >> 31) & 1);
                int hasSeenX = ((seenVal - 1) >> 31) + 1;
                cnt += isPrefixZero & hasSeenX;
            }
        }
        return cnt;
    }
}