using System.Runtime.InteropServices;

namespace LeetCode.Library.Algorithms;

public class Lc1722Solution {
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps) {
        int n = source.Length;
        int[] parent = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
        int find(int x) {
            if (parent[x] != x) {
                parent[x] = find(parent[x]);
            }
            return parent[x];
        }
        void union(int x, int y) {
            parent[find(x)] = find(y);
        }
        
        foreach (var swap in allowedSwaps) {
            union(swap[0], swap[1]);
        }
        // Group indices by their root parent and count the frequency of values in source and target for each group
        Dictionary<int, Dictionary<int, int>> groups = new(n);
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (source[i] == target[i]) {
                continue;
            }

            int sourceValue = source[i];
            int targetValue = target[i];
            int root = find(i);
            if (!groups.TryGetValue(root, out var count)) {
                count = new Dictionary<int, int>();
                groups[root] = count;
            }

            ref int sourceCount = ref CollectionsMarshal.GetValueRefOrAddDefault(count, sourceValue, out _);
            sourceCount++;
            ans += sourceCount > 0 ? 1 : -1;

            ref int targetCount = ref CollectionsMarshal.GetValueRefOrAddDefault(count, targetValue, out _);
            targetCount--;
            ans += targetCount < 0 ? 1 : -1;
        }
        
        return ans >> 1;
    }
}