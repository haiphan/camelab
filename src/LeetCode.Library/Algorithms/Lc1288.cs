namespace LeetCode.Library.Algorithms;

public class Lc1288Solution {
    public int RemoveCoveredIntervals(int[][] intervals) {
        int n = intervals.Length;
        if (n == 0) {
            return 0;
        }

        Array.Sort(intervals, (a, b) => {
            if (a[0] != b[0]) {
                return a[0].CompareTo(b[0]);
            }
            return b[1].CompareTo(a[1]);
        });

        int count = 0;
        int currentEnd = -1;

        for (int i = 0; i < n; i++) {
            int start = intervals[i][0];
            int end = intervals[i][1];

            if (end > currentEnd) {
                count++;
                currentEnd = end;
            }
        }

        return count;
    }
}