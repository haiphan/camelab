namespace LeetCode.Library.Algorithms;

public class Lc2574Solution {
    public int[] LeftRightDifference(int[] nums) {
        int n = nums.Length;
        int right = 0;
        for (int i = 0; i < n; i++) {
            right += nums[i];
        }
        int left = 0;
        for (int i = 0; i < n; i++) {
            int x = nums[i];
            right -= x;
            nums[i] = Math.Abs(left - right);
            left += x;
        }
        return nums;
    }
}