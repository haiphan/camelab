namespace LeetCode.Library.Algorithms;

public class Lc1559Solution {
    public bool ContainsCycle(char[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[] parent = new int[m * n];
        for (int i = 0; i < m * n; i++) {
            parent[i] = i;
        }
        int Find(int[] parent, int x) {
            if (parent[x] != x) {
                parent[x] = Find(parent, parent[x]);
            }
            return parent[x];
        }
        bool Union(int x, int y) {
            int rootX = Find(parent, x), rootY = Find(parent, y);
            if (rootX == rootY) {
                return false;
            }
            parent[rootX] = rootY;
            return true;
        }
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                char c = grid[i][j];
                int id1 = i * n + j;
                if (i > 0 && grid[i - 1][j] == c) {
                    if (!Union(id1, (i - 1) * n + j)) {
                        return true;
                    }
                }
                if (j > 0 && grid[i][j - 1] == c) {
                    if (!Union(id1, i * n + j - 1)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}