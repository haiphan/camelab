namespace LeetCode.Library.Algorithms;

public class Lc3464Solution {
    public int MaxDistance(int side, int[][] points, int k) {
        int m = points.Length;
        long perimeter = 4L * side;
        long[] dists = new long[m];
        for (int i = 0; i < m; i++) {
            int[] point = points[i];
            int x = point[0], y = point[1];
            long dist = 0;
            if (x == 0) {
                dist = y;
            } else if (y == side) {
                dist = side + (long)x;
            } else if (x == side) {
                dist = 3L * side - y;
            } else {
                dist = perimeter - x;
            }
            dists[i] = dist;
        }
        Array.Sort(dists);
        int LowerBound(long target, int left) {
            int right = m;
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (dists[mid] < target) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            return left;
        }

        bool check(long v) {
            Span<int> idx = k <= 64 ? stackalloc int[k] : new int[k];
            long cur = dists[0];
            for (int i = 1; i < k; i++) {
                if (m - idx[i - 1] <= k - i) {
                    return false;
                }
                int j = LowerBound(cur + v, idx[i - 1] + 1);
                if (j == m) {
                    return false;
                }
                idx[i] = j;
                cur = dists[j];
            }
            if (cur - dists[0] <= perimeter - v) {
                return true;
            }
            for (idx[0] = 1; idx[0] <= m - k; idx[0]++) {
                for (int j = 1; j < k; j++) {
                    if (m - idx[j - 1] <= k - j) {
                        return false;
                    }
                    while (idx[j] < m && dists[idx[j]] - dists[idx[j - 1]] < v) {
                        idx[j]++;
                    }
                    if (idx[j] == m) {
                        return false;
                    }
                }
                if (dists[idx[k - 1]] - dists[idx[0]] <= perimeter - v) {
                    return true;
                }
            }
            return false;
        }
        // binary search for the maximum distance
        long left = 0, right = perimeter / k + 1;
        while (left + 1 < right)
        {
            long mid = left + (right - left) / 2;
            if (check(mid)) {
                left = mid;
            } else {
                right = mid;
            }
        }
        return (int)left;
    }
}