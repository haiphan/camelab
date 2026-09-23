namespace LeetCode.Library.Algorithms;

public class Lc1658Solution {
    public int MinOperations(int[] nums, int x) {
        int n = nums.Length;
        int target = -x;
        for (int i = 0; i < n; i++) target += nums[i];
        if (target == 0) return n;
        var dict = new Dictionary<int, int> { { 0, -1 } };
        int sum = 0, maxLen = -1;
        for (int i = 0; i < n; i++) {
            sum += nums[i];
            if (!dict.ContainsKey(sum)) dict[sum] = i;
            if (dict.ContainsKey(sum - target)) maxLen = Math.Max(maxLen, i - dict[sum - target]);
        }
        return maxLen == -1 ? -1 : n - maxLen;
    }
}