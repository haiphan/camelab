namespace LeetCode.Library.Algorithms;

public class Lc2463Solution {
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        int n = robot.Count, m = factory.Length;
        int[] sortedRobot = [.. robot];
        Array.Sort(sortedRobot);
        Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));
        const long BIG = (long)1e18;
        long[] prev = new long[n + 1];
        long[] cur = new long[n + 1];

        prev[0] = 0;
        for (int i = 1; i <= n; i++) {
            prev[i] = BIG;
        }

        int assignedPrevMax = 0;
        for (int j = 0; j < m; j++) {
            int pos = factory[j][0];
            int limit = factory[j][1];
            int assignedCurMax = Math.Min(n, assignedPrevMax + limit);

            for (int i = 0; i <= assignedCurMax; i++) {
                long best = prev[i];
                long dist = 0;
                int minAssign = Math.Max(1, i - assignedPrevMax);
                int maxAssign = Math.Min(i, limit);
                for (int k = 1; k <= maxAssign; k++) {
                    dist += Math.Abs(sortedRobot[i - k] - pos);
                    if (k < minAssign) {
                        continue;
                    }
                    long candidate = prev[i - k] + dist;
                    if (candidate < best) {
                        best = candidate;
                    }
                }
                cur[i] = best;
            }
            for (int i = assignedCurMax + 1; i <= n; i++) {
                cur[i] = BIG;
            }

            (prev, cur) = (cur, prev);
            assignedPrevMax = assignedCurMax;
        }

        return prev[n];
    }
}