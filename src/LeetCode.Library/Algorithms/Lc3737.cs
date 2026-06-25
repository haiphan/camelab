namespace LeetCode.Library.Algorithms;

public class Lc3737Solution {
    public int CountMajoritySubarrays(int[] nums, int target) {
        int n = nums.Length;

        // Map target to +1 and non-target to -1. A subarray has target as majority
        // iff its transformed sum is positive.
        int offset = n + 1;
        int maxIndex = 2 * n + 2;
        var fenwick = new FenwickTree(maxIndex);

        long count = 0;
        int prefix = 0;

        // Prefix sum of 0 before processing any element.
        fenwick.Add(offset, 1);

        for (int i = 0; i < n; i++) {
            prefix += nums[i] == target ? 1 : -1;
            int index = prefix + offset;

            // Count previous prefix sums strictly smaller than current prefix sum.
            count += fenwick.Query(index - 1);
            fenwick.Add(index, 1);
        }

        return (int)count;
    }

    private sealed class FenwickTree {
        private readonly int[] tree;

        public FenwickTree(int size) {
            tree = new int[size + 1];
        }

        public void Add(int index, int delta) {
            for (int i = index; i < tree.Length; i += i & -i) {
                tree[i] += delta;
            }
        }

        public int Query(int index) {
            int sum = 0;
            for (int i = index; i > 0; i -= i & -i) {
                sum += tree[i];
            }
            return sum;
        }
    }
}