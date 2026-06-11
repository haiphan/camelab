namespace LeetCode.Library.Algorithms;

public class Lc3558Solution {
    private int _MOD = 1_000_000_007;
    private int modPow(int x, int n) {
        long result = 1, baseVal = x;
        while (n > 0) {
            if ((n & 1) == 1) result = (result * baseVal) % _MOD;
            baseVal = (baseVal * baseVal) % _MOD;
            n >>= 1;
        }
        return (int)result;
    }
    public int AssignEdgeWeights(int[][] edges) {
        int n = edges.Length + 1;
        List<int>[] graph = new List<int>[n + 1];
        for (int i = 0; i < edges.Length; i++) {
            int u = edges[i][0], v = edges[i][1];
            if (graph[u] == null) graph[u] = new List<int>();
            if (graph[v] == null) graph[v] = new List<int>();
            graph[u].Add(v);
            graph[v].Add(u);
        }
        int dfs(int node, int parent) {
            int d = 0;
            foreach (int neighbor in graph[node]) {
                if (neighbor == parent) continue;
                d = Math.Max(d, dfs(neighbor, node) + 1);
            }
            return d;
        }
        return modPow(2, dfs(1, 0) - 1);
    }
}