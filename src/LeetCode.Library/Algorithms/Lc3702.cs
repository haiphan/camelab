namespace LeetCode.Library.Algorithms;

public class Lc3702Solution {
    public int LongestSubsequence(int[] nums) {
        int total = 0;
        int nonZero = 0;

        foreach (int n in nums) {
            nonZero |= n > 0 ? 1 : 0;
            total ^= n;
        }
        nonZero = nonZero == 0 ? 0 : 1;
        return nonZero * (nums.Length - (total == 0 ? 1 : 0));
    }
}