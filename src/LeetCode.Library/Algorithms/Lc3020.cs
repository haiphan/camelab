namespace LeetCode.Library.Algorithms;

public class Lc3020Solution {
    public int MaximumLength(int[] nums) {
        int n = nums.Length;
        var cm = new IntIntMap(n);
        var keys = new List<int>(n);
        int maxVal = 0;
        for (int i = 0; i < n; i++) {
            int num = nums[i];
            if (cm.Increment(num) == 1) {
                keys.Add(num);
            }
            if (num > maxVal) maxVal = num;
        }

        int ans = 1;

        // Special handling for 1: since 1^2 == 1, we can use all ones.
        if (cm.TryGetValue(1, out int c1)) {
            ans = Math.Max(ans, c1);
        }

        int sqrtMax = (int)Math.Sqrt(maxVal);
        var seen = new HashSet<int>(keys.Count);

        foreach (int k in keys) {
            if (k == 1 || seen.Contains(k)) continue;

            // Compute theoretical max chain length starting from k using maxVal.
            // Math.Log(maxVal)/Math.Log(k) > 1 is equivalent to k < maxVal.
            if (k == maxVal) continue;
            int levels = (int)Math.Floor(Math.Log(Math.Log(maxVal) / Math.Log(k), 2)) + 1;
            // Maximum achievable length from this start is at most 2*levels - 1.
            if (2 * levels - 1 <= ans) continue;

            // skip starts that are the square of a previous node with at least two copies
            int r = (int)Math.Sqrt(k);
            if (r * r == k && cm.TryGetValue(r, out int rCount) && rCount > 1) continue;

            int cur = k;
            int pairs = 0;

            // follow chain cur, cur^2, cur^(4), ... while nodes have at least two copies
            while (true) {
                if (!cm.TryGetValue(cur, out int cnt)) break;
                seen.Add(cur);
                if (cnt > 1) {
                    // If cur is already larger than sqrt(maxVal), cur^2 can't exist in nums.
                    if (cur > sqrtMax) {
                        pairs++;
                        break;
                    }
                    pairs++;
                    // safe to square since cur <= sqrtMax implies cur*cur <= maxVal
                    cur = cur * cur;
                    continue;
                }
                // found a single copy endpoint
                int len = 2 * pairs + 1; // pairs produce 2*pairs, plus this single endpoint
                ans = Math.Max(ans, len);
                goto NextKey;
            }

            // no single endpoint found; length is 2*pairs - 1 (last pair contributes only one)
            int len2 = 2 * pairs - 1;
            if (len2 > 0) ans = Math.Max(ans, len2);

        NextKey: ;
        }

        // Ensure we return an odd length: if even, subtract 1.
        if ((ans & 1) == 0) ans--;
        return ans;
    }

    private sealed class IntIntMap {
        private readonly int[] keys;
        private readonly int[] values;
        private readonly byte[] states;
        private readonly int mask;

        public IntIntMap(int capacity) {
            int size = 1;
            while (size < capacity * 2) size <<= 1;
            keys = new int[size];
            values = new int[size];
            states = new byte[size];
            mask = size - 1;
        }

        private int Probe(int key) {
            int idx = (int)((key * (uint)0x9E3779B1) & (uint)mask);
            while (states[idx] != 0 && keys[idx] != key) {
                idx = (idx + 1) & mask;
            }
            return idx;
        }

        public void Set(int key, int value) {
            int idx = Probe(key);
            keys[idx] = key;
            values[idx] = value;
            states[idx] = 1;
        }

        public int Increment(int key) {
            int idx = Probe(key);
            if (states[idx] == 0) {
                keys[idx] = key;
                values[idx] = 1;
                states[idx] = 1;
                return 1;
            }
            values[idx]++;
            return values[idx];
        }

        public bool TryGetValue(int key, out int value) {
            int idx = (int)((key * (uint)0x9E3779B1) & (uint)mask);
            while (states[idx] != 0) {
                if (keys[idx] == key) {
                    value = values[idx];
                    return true;
                }
                idx = (idx + 1) & mask;
            }
            value = 0;
            return false;
        }
    }
}