namespace LeetCode.Library.Algorithms;

public class Lc3660Solution {
    public int[] MaxValue(int[] nums) {
        int n = nums.Length;
        int[] ans = new int[n];
        // pre[i] = max(nums[0], nums[1], ..., nums[i])
        int[] pre = new int[n];
        // suf[i] = min(nums[i], nums[i+1], ..., nums[n-1])
        int[] suf = new int[n];
        pre[0] = nums[0];
        for (int i = 1; i < n; i++) {
            pre[i] = Math.Max(pre[i - 1], nums[i]);
        }
        suf[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            suf[i] = Math.Min(suf[i + 1], nums[i]);
        }
        ans[n - 1] = pre[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            if (pre[i] > suf[i + 1]) {
                ans[i] = ans[i + 1];
            } else {
                ans[i] = pre[i];
            }
        }
        return ans;
    }
}