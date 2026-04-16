namespace LeetCode.Library.Algorithms;

public class Lc3488Solution {
    private struct ChainInfo {
        public int First;
        public int Last;
        public int Count;
    }

    private sealed class LinearProbingMap {
        private readonly int[] keys;
        private readonly ChainInfo[] values;
        private readonly bool[] used;
        private readonly int mask;

        public LinearProbingMap(int expectedCount) {
            int capacity = 1;
            int target = Math.Max(4, expectedCount * 4);
            while (capacity < target) {
                capacity <<= 1;
            }

            keys = new int[capacity];
            values = new ChainInfo[capacity];
            used = new bool[capacity];
            mask = capacity - 1;
        }

        public bool TryGetValue(int key, out ChainInfo value) {
            int idx = Hash(key);
            while (used[idx]) {
                if (keys[idx] == key) {
                    value = values[idx];
                    return true;
                }
                idx = (idx + 1) & mask;
            }

            value = default;
            return false;
        }

        public void Set(int key, ChainInfo value) {
            int idx = Hash(key);
            while (used[idx]) {
                if (keys[idx] == key) {
                    values[idx] = value;
                    return;
                }
                idx = (idx + 1) & mask;
            }

            used[idx] = true;
            keys[idx] = key;
            values[idx] = value;
        }

        public void ForEachValue(Action<ChainInfo> action) {
            for (int i = 0; i < used.Length; i++) {
                if (used[i]) {
                    action(values[i]);
                }
            }
        }

        private int Hash(int key) {
            return (int)(((uint)key * 2654435761u) & (uint)mask);
        }
    }

    public IList<int> SolveQueries(int[] nums, int[] queries) {
        int n = nums.Length;
        int m = queries.Length;
        var ans = new int[m];
        var map = new LinearProbingMap(n);
        int[] next = new int[n];
        int[] prev = new int[n];
        Array.Fill(next, -1);
        Array.Fill(prev, -1);

        for (int i = 0; i < n; i++) {
            int value = nums[i];
            if (!map.TryGetValue(value, out var info)) {
                info.First = i;
                info.Last = i;
                info.Count = 1;
                map.Set(value, info);
                continue;
            }

            next[info.Last] = i;
            prev[i] = info.Last;
            info.Last = i;
            info.Count++;
            map.Set(value, info);
        }

        map.ForEachValue(info => {
            if (info.Count <= 1) {
                return;
            }

            next[info.Last] = info.First;
            prev[info.First] = info.Last;
        });

        for (int i = 0; i < m; i++) {
            int q = queries[i];
            int left = prev[q];
            if (left == -1) {
                ans[i] = -1;
                continue;
            }

            int dl = Math.Abs(q - left);
            dl = Math.Min(dl, n - dl);

            int right = next[q];
            int dr = Math.Abs(q - right);
            dr = Math.Min(dr, n - dr);

            ans[i] = Math.Min(dl, dr);
        }

        return ans;
    }
}