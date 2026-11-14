namespace LeetCode.Library.Algorithms;

public class Lc3364Solution {
    public int MinimumSumSubarray(IList<int> nums, int l, int r) {
        int n = nums.Count;
        int[] prefix = new int[n + 1];  // prefix[i] = sum of nums[0..i-1]
        for (int i = 0; i < n; i++) {
            prefix[i + 1] = prefix[i] + nums[i];
        }
        int minSum = int.MaxValue;
        for (int i = 0; i <= n - l; i++) {
            int maxLen = Math.Min(r, n - i);
            for (int len = l; len <= maxLen; len++) {  // sum of nums[i..i+len-1] via prefix difference, O(1) per length
                int sum = prefix[i + len] - prefix[i];
                if (sum > 0) {
                    minSum = Math.Min(minSum, sum);
                }
            }
        }
        return minSum == int.MaxValue ? -1 : minSum;
    }
}