namespace LeetCode.Library.Algorithms;

public class Lc2747Solution {
    public int[] CountServers(int n, int[][] logs, int x, int[] queries) {
        int L = logs.Length;
        int Q = queries.Length;

        // Flatten logs into parallel key/value arrays so Array.Sort can use the
        // primitive paired-array overload instead of a comparator delegate.
        int[] logTimes = new int[L];
        int[] logServers = new int[L];
        for (int i = 0; i < L; i++) {
            logServers[i] = logs[i][0];
            logTimes[i] = logs[i][1];
        }
        Array.Sort(logTimes, logServers);

        // Process queries in ascending order so both window pointers only move forward.
        int[] sortedQueries = (int[])queries.Clone();
        int[] order = new int[Q];
        for (int i = 0; i < Q; i++)
        {
            order[i] = i;
        }

        Array.Sort(sortedQueries, order);

        int[] ans = new int[Q];
        int[] cnt = new int[n + 1];
        int active = 0;
        int start = 0, end = 0;

        for (int i = 0; i < Q; i++) {
            int right = sortedQueries[i];
            int left = right - x;

            while (end < L && logTimes[end] <= right) {
                int server = logServers[end];
                if (cnt[server]++ == 0)
                {
                    active++;
                }

                end++;
            }

            while (start < L && logTimes[start] < left) {
                int server = logServers[start];
                if (--cnt[server] == 0)
                {
                    active--;
                }

                start++;
            }

            ans[order[i]] = n - active;
        }

        return ans;
    }
}