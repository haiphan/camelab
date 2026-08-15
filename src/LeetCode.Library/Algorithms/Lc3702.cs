namespace LeetCode.Library.Algorithms;

public class Lc3702Solution {
    public int LongestSubsequence(int[] nums) {
        int total = 0;
        bool nonZero = false;

        foreach (int n in nums) {
            nonZero |= n != 0;
            total ^= n;
        }
        if (!nonZero) {
            return 0;
        }
        return nums.Length - (total == 0 ? 1 : 0);
    }
}