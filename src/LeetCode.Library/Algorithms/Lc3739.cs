namespace LeetCode.Library.Algorithms;

public class Lc3739Solution {
    public long CountMajoritySubarrays(int[] nums, int target) {
        int n = nums.Length;

        // Transform nums: target -> +1, non-target -> -1.
        // A subarray has target as majority iff transformed sum > 0.
        int offset = n;
        var freq = new int[2 * n + 1];

        long count = 0;
        int prefix = 0;
        long lessThanCurrent = 0;

        // Include prefix sum 0 before any element.
        freq[offset] = 1;

        for (int i = 0; i < n; i++) {
            int delta = nums[i] == target ? 1 : -1;
            int oldPrefix = prefix;
            prefix += delta;

            // Maintain count of seen prefix sums strictly less than current prefix.
            if (delta == 1) {
                lessThanCurrent += freq[oldPrefix + offset];
            } else {
                lessThanCurrent -= freq[prefix + offset];
            }

            count += lessThanCurrent;
            freq[prefix + offset]++;
        }

        return count;
    }
}