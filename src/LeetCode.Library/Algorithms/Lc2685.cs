namespace LeetCode.Library.Algorithms;

public class Lc2685Solution {
    public int CountCompleteComponents(int n, int[][] edges) {
        int[] parent = new int[n];
        int[] size = new int[n];
        int[] edgeCount = new int[n];
        bool[] seen = new bool[n];

        int Find(int x) {
            if (parent[x] != x) {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        void AddEdge(int x, int y) {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX == rootY) {
                edgeCount[rootX]++;
                return;
            }

            if (size[rootX] < size[rootY]) {
                (rootX, rootY) = (rootY, rootX);
            }

            parent[rootY] = rootX;
            size[rootX] += size[rootY];
            edgeCount[rootX] += edgeCount[rootY] + 1;
        }

        for (int i = 0; i < n; i++) {
            parent[i] = i;
            size[i] = 1;
        }

        foreach (var edge in edges) {
            int u = edge[0];
            int v = edge[1];
            AddEdge(u, v);
        }

        int completeComponents = 0;
        for (int i = 0; i < n; i++) {
            int root = Find(i);
            if (seen[root]) {
                continue;
            }
            seen[root] = true;

            long expectedEdges = (long)size[root] * (size[root] - 1) / 2;
            if (edgeCount[root] == expectedEdges) {
                completeComponents++;
            }
        }

        return completeComponents;
    }
}