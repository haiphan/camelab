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
        // CSR graph: head[i]..head[i+1]-1 are indices into adj[] for node i
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
        // Level-by-level BFS: depth as a counter, no depth[] array needed
        int maxDepth = 0;
        bool[] visited = new bool[n + 1];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        visited[1] = true;
        while (queue.Count > 0) {
            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++) {
                int node = queue.Dequeue();
                for (int j = head[node]; j < head[node + 1]; j++) {
                    int neighbor = adj[j];
                    if (!visited[neighbor]) {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            maxDepth++;
        }
        return modPow(2, maxDepth - 2);
    }
}