namespace LeetCode.Library.Algorithms;

public class Lc799Solution {
    public void ResetFristK(List<double> list, int k) {
        int u = Math.Min(list.Count, k);
        for (int i = 0; i < u; i++) {
            list[i] = 0;
        }
        if (u < k) {
            for (int i = u; i < k; i++) {
                list.Add(0);
            }
        }
    }
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        if (query_row < 30) { // Safe threshold (2^31-1 > 1e9)
            int threshold = (1 << (query_row + 1)) - 1;
            if (poured >= threshold) {
                return 1.0;
            }
        }

        // Estimate max row reachable: n = (-3 + sqrt(1 + 8*poured)) / 2
        int estimatedMaxRow = (int)((-3 + Math.Sqrt(1 + 8.0 * poured)) / 2);
        int capacity = Math.Min(estimatedMaxRow + 2, query_row + 2);
        var cur = new List<double>(capacity);
        var next = new List<double>(capacity);
        cur.Add(poured);
        for (int i = 0; i <= query_row; i++)  {
            ResetFristK(next, i + 2);
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
                (cur, next) = (next, cur);
            }
            if (!hasWater) return 0;
        }
        return cur[query_glass];
    }
}