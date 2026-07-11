namespace LeetCode.Library.Algorithms;

public class Lc2685Solution {
    public int CountCompleteComponents(int n, int[][] edges) {
        int m = edges.Length;
        int[] head = new int[n];
        int[] to = new int[m * 2];
        int[] next = new int[m * 2];
        bool[] seen = new bool[n];
        Array.Fill(head, -1);

        void AddUndirectedEdge(int u, int v, ref int edgeIndex) {
            to[edgeIndex] = v;
            next[edgeIndex] = head[u];
            head[u] = edgeIndex;
            edgeIndex++;
        }

        int edgePtr = 0;
        foreach (var edge in edges) {
            int u = edge[0];
            int v = edge[1];
            AddUndirectedEdge(u, v, ref edgePtr);
            AddUndirectedEdge(v, u, ref edgePtr);
        }

        int completeComponents = 0;

        void Dfs(int start, ref int vertexCount, ref int directedEdgeCount) {
            seen[start] = true;
            vertexCount++;

            for (int e = head[start]; e != -1; e = next[e]) {
                directedEdgeCount++;
                int neighbor = to[e];
                if (!seen[neighbor]) {
                    Dfs(neighbor, ref vertexCount, ref directedEdgeCount);
                }
            }
        }

        for (int i = 0; i < n; i++) {
            if (seen[i]) {
                continue;
            }

            int vertexCount = 0;
            int directedEdgeCount = 0;
            Dfs(i, ref vertexCount, ref directedEdgeCount);

            int undirectedEdgeCount = directedEdgeCount / 2;
            int expectedEdges = vertexCount * (vertexCount - 1) / 2;
            if (undirectedEdgeCount == expectedEdges) {
                completeComponents++;
            }
        }

        return completeComponents;
    }
}