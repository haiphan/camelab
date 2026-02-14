namespace LeetCode.Library.Algorithms;

public class Lc799Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        if (query_row < 30) { // Safe threshold (2^31-1 > 1e9)
            int threshold = (1 << (query_row + 1)) - 1;
            if (poured >= threshold) {
                return 1.0;
            }
        }
        double[] cur = new double[1];
        cur[0] = poured;
        for (int i = 0; i <= query_row; i++)  {
            double[] next = new double[i + 2];
            bool hasWater = false;
            for (int j = 0; j <= i; j++) {
                double v = cur[j];
                hasWater = hasWater || (v > 0);
                if (v > 1.0) {
                    double r = (v - 1.0) / 2.0;
                    next[j] += r;
                    next[j + 1] += r;
                    cur[j] = 1.0;
                }
            }
            if (i < query_row) {
                cur = next;
            }
            if (!hasWater) return 0;
        }
        return cur[query_glass];
    }
}