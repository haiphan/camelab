namespace LeetCode.Library.Algorithms;

public class Lc3620Solution {
    public int FindMaxPathScore(int[][] edges, bool[] online, long k) {
        int n = online.Length;
        if (n == 0 || k < 0 || !online[0] || !online[n - 1]) {
            return -1;
        }

        int m = edges.Length;
        int[] edgeFrom = new int[m];
        int[] edgeTo = new int[m];
        int[] edgeW = new int[m];
        int[] outDegree = new int[n];
        int[] indegree = new int[n];

        for (int i = 0; i < m; i++) {
            int u = edges[i][0];
            int v = edges[i][1];
            int w = edges[i][2];
            edgeFrom[i] = u;
            edgeTo[i] = v;
            edgeW[i] = w;
            outDegree[u]++;
            if (online[u] && online[v]) {
                indegree[v]++;
            }
        }

        int[] head = new int[n + 1];
        for (int i = 0; i < n; i++) {
            head[i + 1] = head[i] + outDegree[i];
        }

        int[] to = new int[m];
        int[] weight = new int[m];
        int[] cursor = new int[n];
        Array.Copy(head, cursor, n);
        for (int i = 0; i < m; i++) {
            int u = edgeFrom[i];
            int idx = cursor[u]++;
            to[idx] = edgeTo[i];
            weight[idx] = edgeW[i];
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
            for (int e = head[u]; e < head[u + 1]; e++) {
                int v = to[e];
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
            for (int e = head[u]; e < head[u + 1]; e++) {
                int v = to[e];
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
            for (int e = head[u]; e < head[u + 1]; e++) {
                int v = to[e];
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
        List<int> activeTopo = new List<int>(topo.Count);
        for (int i = 0; i < topo.Count; i++) {
            int u = topo[i];
            if (fromStart[u] && toEnd[u]) {
                active[u] = true;
                activeTopo.Add(u);
            }
        }

        int[] activeOutDegree = new int[n];
        int activeEdgeCount = 0;
        int maxActiveWeight = 0;
        for (int i = 0; i < m; i++) {
            int u = edgeFrom[i];
            int v = edgeTo[i];
            if (active[u] && active[v]) {
                activeOutDegree[u]++;
                activeEdgeCount++;
                if (edgeW[i] > maxActiveWeight) {
                    maxActiveWeight = edgeW[i];
                }
            }
        }

        if (activeEdgeCount == 0) {
            return -1;
        }

        int[] activeHead = new int[n + 1];
        for (int i = 0; i < n; i++) {
            activeHead[i + 1] = activeHead[i] + activeOutDegree[i];
        }

        int[] activeTo = new int[activeEdgeCount];
        int[] activeWeight = new int[activeEdgeCount];
        int[] activeCursor = new int[n];
        Array.Copy(activeHead, activeCursor, n);
        for (int i = 0; i < m; i++) {
            int u = edgeFrom[i];
            int v = edgeTo[i];
            if (!active[u] || !active[v]) {
                continue;
            }
            int idx = activeCursor[u]++;
            activeTo[idx] = v;
            activeWeight[idx] = edgeW[i];
        }

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
                for (int e = activeHead[u]; e < activeHead[u + 1]; e++) {
                    int v = activeTo[e];
                    int w = activeWeight[e];
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

        int left = 0;
        int right = maxActiveWeight;
        int answer = -1;
        while (left <= right) {
            int mid = left + ((right - left) >> 1);
            if (CanAchieve(mid)) {
                answer = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return answer;
    }
}
