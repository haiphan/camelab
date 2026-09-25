namespace LeetCode.Library.Algorithms;

public class Lc1658Solution {
    public int MinOperations(int[] nums, int x) {
        int n = nums.Length;
        int target = -x;
        for (int i = 0; i < n; i++) target += nums[i];
        if (target < 0) return -1;
        if (target == 0) return n;
        // nums are all positive, so a sliding window finds the longest subarray summing to target in O(1) space.
        int left = 0, sum = 0, maxLen = -1;
        for (int right = 0; right < n; right++) {
            sum += nums[right];
            while (sum > target) sum -= nums[left++];
            if (sum == target) maxLen = Math.Max(maxLen, right - left + 1);
        }
        return maxLen == -1 ? -1 : n - maxLen;
    }
}