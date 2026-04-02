namespace LeetCode.Library.Algorithms;

public class Lc3418Solution {
    public int MaximumAmount(int[][] coins) {
        int n = coins.Length, m = coins[0].Length;
        int SMALL = -1000000000;
        int[] prev = new int[m * 3];
        Array.Fill(prev, SMALL);

        static int Idx(int j, int k) {
            return (j * 3) + k;
        }

        prev[Idx(0, 0)] = coins[0][0];
        prev[Idx(0, 1)] = 0;
        prev[Idx(0, 2)] = 0;

        for (int j = 1; j < m; j++) {
            int v = coins[0][j];
            int baseIdx = j * 3;
            int leftBaseIdx = baseIdx - 3;
            int left0 = prev[leftBaseIdx];
            int left1 = prev[leftBaseIdx + 1];
            int left2 = prev[leftBaseIdx + 2];
            prev[baseIdx] = left0 + v;
            prev[baseIdx + 1] = Math.Max(left1 + v, left0);
            prev[baseIdx + 2] = Math.Max(left2 + v, left1);
        }

        for (int i = 1; i < n; i++) {
            int v0 = coins[i][0];
            int up00 = prev[Idx(0, 0)];
            int up01 = prev[Idx(0, 1)];
            int up02 = prev[Idx(0, 2)];
            prev[Idx(0, 0)] = up00 + v0;
            prev[Idx(0, 1)] = Math.Max(up01 + v0, up00);
            prev[Idx(0, 2)] = Math.Max(up02 + v0, up01);

            for (int j = 1; j < m; j++) {
                int v = coins[i][j];
                int baseIdx = j * 3;
                int leftBaseIdx = baseIdx - 3;

                int up0 = prev[baseIdx];
                int up1 = prev[baseIdx + 1];
                int up2 = prev[baseIdx + 2];

                int left0 = prev[leftBaseIdx];
                int left1 = prev[leftBaseIdx + 1];
                int left2 = prev[leftBaseIdx + 2];

                int best0 = Math.Max(up0 + v, left0 + v);
                int best1 = Math.Max(Math.Max(up1 + v, left1 + v), Math.Max(up0, left0));
                int best2 = Math.Max(Math.Max(up2 + v, left2 + v), Math.Max(up1, left1));

                prev[baseIdx] = best0;
                prev[baseIdx + 1] = best1;
                prev[baseIdx + 2] = best2;
            }
        }
        int lastBaseIdx = (m - 1) * 3;
        return Math.Max(
            prev[lastBaseIdx],
            Math.Max(prev[lastBaseIdx + 1], prev[lastBaseIdx + 2])
        );
    }
}