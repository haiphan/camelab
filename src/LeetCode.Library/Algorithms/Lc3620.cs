namespace LeetCode.Library.Algorithms;

public class Lc3620Solution {
    public int FindMaxPathScore(int[][] edges, bool[] online, long k) {
        int n = online.Length;
        if (n == 0 || k < 0 || !online[0] || !online[n - 1]) {
            return -1;
        }

        List<(int to, int w)>[] graph = new List<(int to, int w)>[n];
        int[] indegree = new int[n];

        for (int i = 0; i < n; i++) {
            graph[i] = new List<(int to, int w)>();
        }

        foreach (int[] e in edges) {
            int u = e[0], v = e[1], w = e[2];
            graph[u].Add((v, w));
            if (online[u] && online[v]) {
                indegree[v]++;
            }
        }

        Queue<int> queue = new Queue<int>();
        List<int> topo = new List<int>(n);
        for (int i = 0; i < n; i++) {
            if (online[i] && indegree[i] == 0) {
                queue.Enqueue(i);
            }
        }

        while (queue.Count > 0) {
            int u = queue.Dequeue();
            topo.Add(u);
            foreach ((int v, int _) in graph[u]) {
                if (!online[v]) {
                    continue;
                }
                indegree[v]--;
                if (indegree[v] == 0) {
                    queue.Enqueue(v);
                }
            }
        }

        bool[] fromStart = new bool[n];
        fromStart[0] = true;
        foreach (int u in topo) {
            if (!fromStart[u]) {
                continue;
            }
            foreach ((int v, int _) in graph[u]) {
                if (online[v]) {
                    fromStart[v] = true;
                }
            }
        }

        if (!fromStart[n - 1]) {
            return -1;
        }

        bool[] toEnd = new bool[n];
        toEnd[n - 1] = true;
        for (int i = topo.Count - 1; i >= 0; i--) {
            int u = topo[i];
            foreach ((int v, int _) in graph[u]) {
                if (online[v] && toEnd[v]) {
                    toEnd[u] = true;
                    break;
                }
            }
        }

        if (!toEnd[0]) {
            return -1;
        }

        bool[] active = new bool[n];
        List<int> activeTopo = new List<int>();
        for (int i = 0; i < topo.Count; i++) {
            int u = topo[i];
            if (fromStart[u] && toEnd[u]) {
                active[u] = true;
                activeTopo.Add(u);
            }
        }

        List<(int to, int w)>[] prunedGraph = new List<(int to, int w)>[n];
        for (int i = 0; i < n; i++) {
            prunedGraph[i] = new List<(int to, int w)>();
        }

        List<int> candidates = new List<int>();
        foreach (int[] e in edges) {
            int u = e[0], v = e[1], w = e[2];
            if (active[u] && active[v]) {
                prunedGraph[u].Add((v, w));
                candidates.Add(w);
            }
        }

        if (candidates.Count == 0) {
            return -1;
        }

        candidates.Sort();
        int uniqueCount = 1;
        for (int i = 1; i < candidates.Count; i++) {
            if (candidates[i] != candidates[uniqueCount - 1]) {
                candidates[uniqueCount++] = candidates[i];
            }
        }
        candidates.RemoveRange(uniqueCount, candidates.Count - uniqueCount);

        long[] dist = new long[n];
        int[] seen = new int[n];
        int stamp = 0;

        bool CanAchieve(int minEdge) {
            stamp++;
            dist[0] = 0;
            seen[0] = stamp;

            foreach (int u in activeTopo) {
                if (seen[u] != stamp || dist[u] > k) {
                    continue;
                }
                foreach ((int v, int w) in prunedGraph[u]) {
                    if (w < minEdge) {
                        continue;
                    }
                    long nd = dist[u] + w;
                    if (nd <= k && (seen[v] != stamp || nd < dist[v])) {
                        seen[v] = stamp;
                        dist[v] = nd;
                    }
                }
            }
            return seen[n - 1] == stamp && dist[n - 1] <= k;
        }

        int left = 0, right = candidates.Count - 1;
        int answer = -1;

        while (left <= right) {
            int mid = left + ((right - left) >> 1);
            int target = candidates[mid];
            if (CanAchieve(target)) {
                answer = target;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return answer;
    }
}