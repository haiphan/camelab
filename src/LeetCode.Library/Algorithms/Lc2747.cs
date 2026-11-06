namespace LeetCode.Library.Algorithms;

public class Lc2747Solution {
    public int[] CountServers(int n, int[][] logs, int x, int[] queries) {
        int L = logs.Length;
        int Q = queries.Length;

        if (L == 0)
        {
            // No requests ever happened, so every server is idle for every query.
            int[] allIdle = new int[Q];
            Array.Fill(allIdle, n);
            return allIdle;
        }

        Array.Sort(logs, (a, b) => a[1].CompareTo(b[1]));

        // Process queries in ascending order so both window pointers only move forward.
        int[] order = Enumerable.Range(0, Q).ToArray();
        Array.Sort(order, (a, b) => queries[a].CompareTo(queries[b]));

        int[] ans = new int[Q];
        int[] cnt = new int[n + 1];
        int active = 0;
        int start = 0, end = 0;

        for (int i = 0; i < Q; i++) {
            int idx = order[i];
            int right = queries[idx];
            int left = right - x;

            while (end < L && logs[end][1] <= right) {
                int server = logs[end][0];
                if (cnt[server]++ == 0)
                {
                    active++;
                }

                end++;
            }

            while (start < L && logs[start][1] < left) {
                int server = logs[start][0];
                if (--cnt[server] == 0)
                {
                    active--;
                }

                start++;
            }

            ans[idx] = n - active;

            // start == L means every log is behind the window for good; since queries
            // are processed in ascending order, all remaining queries are also idle.
            if (start == L) {
                for (int j = i + 1; j < Q; j++)
                {
                    ans[order[j]] = n;
                }

                break;
            }
        }

        return ans;
    }
}