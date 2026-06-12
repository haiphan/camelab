namespace LeetCode.Library.Algorithms;

public class Lc3559Solution {
    private const int MOD = 1_000_000_007;
    private const int LOG = 17; // 2^17 > 100000

    public int[] AssignEdgeWeights(int[][] edges, int[][] queries) {
        int n = edges.Length + 1;

        // CSR graph (same pattern as Lc3558)
        int[] degree = new int[n + 1];
        foreach (int[] e in edges) { degree[e[0]]++; degree[e[1]]++; }
        int[] head = new int[n + 2];
        for (int i = 1; i <= n; i++) head[i + 1] = head[i] + degree[i];
        int[] adj = new int[2 * edges.Length];
        int[] pos = new int[n + 1];
        for (int i = 1; i <= n; i++) pos[i] = head[i];
        foreach (int[] e in edges) {
            adj[pos[e[0]]++] = e[1];
            adj[pos[e[1]]++] = e[0];
        }

        // BFS from root 1 to get depth[] and direct parent
        int[] depth = new int[n + 1];
        int[] up0 = new int[n + 1]; // direct parent; up0[1] = 0 (sentinel)
        bool[] visited = new bool[n + 1];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        visited[1] = true;
        while (queue.Count > 0) {
            int node = queue.Dequeue();
            for (int j = head[node]; j < head[node + 1]; j++) {
                int nb = adj[j];
                if (!visited[nb]) {
                    visited[nb] = true;
                    depth[nb] = depth[node] + 1;
                    up0[nb] = node;
                    queue.Enqueue(nb);
                }
            }
        }

        // Binary lifting: up[j][i] = 2^j-th ancestor of i
        int[][] up = new int[LOG][];
        for (int j = 0; j < LOG; j++) up[j] = new int[n + 1];
        for (int i = 1; i <= n; i++) up[0][i] = up0[i];
        for (int j = 1; j < LOG; j++)
            for (int i = 1; i <= n; i++)
                up[j][i] = up[j - 1][up[j - 1][i]];

        int lca(int u, int v) {
            if (depth[u] < depth[v]) { int t = u; u = v; v = t; }
            int diff = depth[u] - depth[v];
            for (int j = 0; j < LOG; j++)
                if (((diff >> j) & 1) == 1) u = up[j][u];
            if (u == v) return u;
            for (int j = LOG - 1; j >= 0; j--)
                if (up[j][u] != up[j][v]) { u = up[j][u]; v = up[j][v]; }
            return up[0][u];
        }

        // For each query [u,v]: count edge-weight assignments in {1,2} on the u-v path
        // such that the total distance is odd.
        // With k = hop-dist(u,v) edges on path: answer = 2^(k-1) mod MOD (k > 0), else 0.
        long[] pow2 = new long[n + 1];
        pow2[0] = 1;
        for (int i = 1; i <= n; i++) pow2[i] = pow2[i - 1] * 2 % MOD;

        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            int u = queries[i][0], v = queries[i][1];
            int l = lca(u, v);
            int k = depth[u] + depth[v] - 2 * depth[l]; // hop count
            result[i] = k == 0 ? 0 : (int)pow2[k - 1];
        }
        return result;
    }
}