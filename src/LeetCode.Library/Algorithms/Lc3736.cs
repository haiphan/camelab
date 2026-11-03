namespace LeetCode.Library.Algorithms;

public class Lc3736Solution {
    public int MinMoves(int[] nums) {
        int n = nums.Length;
        int maxv = nums[0];
        int sum = nums[0];
        for (int i = 1; i < n; i++) {
            maxv = Math.Max(maxv, nums[i]);
            sum += nums[i];
        }
        return n * maxv - sum;
    }
}