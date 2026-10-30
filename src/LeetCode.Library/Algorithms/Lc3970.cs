namespace LeetCode.Library.Algorithms;

public class Lc3970Solution {
    public int ShortestPath(int n, int[][] edges, string labels, int k) {
        // Directed CSR adjacency: avoids per-node List<int> allocations.
        int m = edges.Length;
        int[] outDegree = new int[n];
        foreach (int[] e in edges)
        {
            outDegree[e[0]]++;
        }
        int[] adjStart = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            adjStart[i + 1] = adjStart[i] + outDegree[i];
        }
        int[] adjTo = new int[m];
        int[] adjWeight = new int[m];
        int[] insertPos = (int[])adjStart.Clone();
        foreach (int[] e in edges)
        {
            int u = e[0];
            adjTo[insertPos[u]] = e[1];
            adjWeight[insertPos[u]] = e[2];
            insertPos[u]++;
        }

        // State = (node, run length of consecutive identical labels ending at node), run in [1, k].
        char[] lab = labels.ToCharArray();
        const long Inf = long.MaxValue / 2;
        long[] dist = new long[n * k];
        Array.Fill(dist, Inf);
        var pq = new PriorityQueue<int, long>();
        int startState = 0; // node 0, run = 1
        dist[startState] = 0;
        pq.Enqueue(startState, 0);

        while (pq.TryDequeue(out int state, out long d))
        {
            if (d > dist[state])
            {
                continue; // stale entry
            }

            int u = state / k;
            if (u == n - 1)
            {
                return (int)d;
            }

            int run = state % k + 1;
            for (int idx = adjStart[u]; idx < adjStart[u + 1]; idx++)
            {
                int v = adjTo[idx];
                int newRun = lab[v] == lab[u] ? run + 1 : 1;
                if (newRun > k)
                {
                    continue; // would exceed k consecutive identical labels
                }

                long nd = d + adjWeight[idx];
                int newState = v * k + (newRun - 1);
                if (nd < dist[newState])
                {
                    dist[newState] = nd;
                    pq.Enqueue(newState, nd);
                }
            }
        }

        return -1;
    }
}
