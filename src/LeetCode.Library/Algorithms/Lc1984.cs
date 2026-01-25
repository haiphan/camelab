namespace LeetCode.Library.Algorithms;

public class Lc1984Solution {
    public int MinimumDifference(int[] nums, int k) {
        if (k == 1) {
            return 0;
        }
        Array.Sort(nums);
        int n = nums.Length;
        int ans = int.MaxValue;;
        int ub = n - k;
        for (int i = 0; i <= ub; i++) {
            ans = Math.Min(ans, nums[i + k - 1] - nums[i]);
        }
        return ans;
    }
}