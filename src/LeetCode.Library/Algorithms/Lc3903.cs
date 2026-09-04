namespace LeetCode.Library.Algorithms;

public class Lc3903Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int n = nums.Length;
        if (n == 1) return 0;
        int[] sufMin = new int[n];
        sufMin[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            sufMin[i] = Math.Min(sufMin[i + 1], nums[i]);
        }
        int preMax = nums[0];
        for (int i = 0; i < n; i++) {
            preMax = Math.Max(preMax, nums[i]);
            int d = preMax - sufMin[i];
            if (d <= k) {
                return i;
            }
        }
        return -1;
    }
}