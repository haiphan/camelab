namespace LeetCode.Library.Algorithms;

public class Lc3310Solution {
    public IList<int> RemainingMethods(int n, int k, int[][] invocations) {
        if (invocations.Length == 0) {
            List<int> remainWithoutK = new List<int>(n - 1);
            for (int i = 0; i < n; i++) {
                if (i != k) {
                    remainWithoutK.Add(i);
                }
            }

            return remainWithoutK;
        }

        int m = invocations.Length;
        int[] head = new int[n];
        Array.Fill(head, -1);
        int[] to = new int[m];
        int[] next = new int[m];
        for (int i = 0; i < m; i++) {
            int from = invocations[i][0];
            to[i] = invocations[i][1];
            next[i] = head[from];
            head[from] = i;
        }

        bool[] vis = new bool[n];
        int suspiciousCount = 1;
        int[] q = new int[n];
        int queueHead = 0;
        int queueTail = 0;
        q[queueTail++] = k;
        vis[k] = true;
        while (queueHead < queueTail) {
            int u = q[queueHead++];
            for (int edge = head[u]; edge != -1; edge = next[edge]) {
                int v = to[edge];
                if (!vis[v]) {
                    vis[v] = true;
                    suspiciousCount++;
                    q[queueTail++] = v;
                }
            }
        }

        if (suspiciousCount == n) {
            return [];
        }

        foreach (var e in invocations) {
            if (!vis[e[0]] && vis[e[1]]) {
                List<int> remain = new List<int>(n);
                for (int i = 0; i < n; i++) {
                    remain.Add(i);
                }
                return remain;
            }
        }

        List<int> ans = new List<int>(n);
        for (int i = 0; i < n; i++) {
            if (!vis[i]) {
                ans.Add(i);
            }
        }

        return ans;
    }
}