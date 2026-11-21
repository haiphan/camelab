namespace LeetCode.Library.Algorithms;

public class Lc3331Solution {
    public int[] FindSubtreeSizes(int[] parent, string s) {
        int n = parent.Length;
        int[] result = new int[n];
        // Flat singly-linked adjacency list: childHead[p] is the first child of p,
        // childNext[c] is c's next sibling. Avoids n List<int> allocations and keeps
        // traversal data in two contiguous int[] buffers.
        int[] childHead = new int[n];
        Array.Fill(childHead, -1);
        int[] childNext = new int[n];
        for (int i = 0; i < n; i++) {
            result[i] = 1;
            int p = parent[i];
            if (p != -1) {
                childNext[i] = childHead[p];
                childHead[p] = i;
            }
        }
        // s consists of lowercase English letters, so a 26-slot array is a cheaper
        // stand-in for Dictionary<char, int> (no hashing/boxing on the hot path).
        int[] last = new int[26];
        Array.Fill(last, -1);
        void Dfs(int node) {
            int c = s[node] - 'a';
            int above = last[c];
            last[c] = node;
            for (int child = childHead[node]; child != -1; child = childNext[child]) {
                Dfs(child);
            }
            last[c] = above;
            if (node > 0) {
                int y = above;
                if (y < 0)
                {
                    y = parent[node];
                }
                result[y] += result[node];
            }
        }
        Dfs(0);
        return result;
    }
}