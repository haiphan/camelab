namespace LeetCode.Library.Algorithms;

public class Lc3650Solution {
    public int MinCost(int n, int[][] edges) {
        var adj = new List<(int to, int weight)>[n];
        for (int i = 0; i < n; i++) adj[i] = [];
        
        foreach (var edge in edges) {
            adj[edge[0]].Add((edge[1], edge[2]));
            adj[edge[1]].Add((edge[0], edge[2] * 2));
        }
        int[] dists = new int[n];
        Array.Fill(dists, int.MaxValue);
        dists[0] = 0;
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(0, 0);
        while (pq.TryDequeue(out int u, out int d)) {
            // Optimization: If we found a shorter path to u already, skip this stale entry
            if (d > dists[u]) continue;
            
            // Goal reached? We can return early in Dijkstra
            if (u == n - 1) return d;

            foreach (var (v, weight) in adj[u]) {
                // Relaxation step
                if (dists[u] + weight < dists[v]) {
                    dists[v] = dists[u] + weight;
                    pq.Enqueue(v, dists[v]);
                }
            }
        }
        return -1;
    }
}