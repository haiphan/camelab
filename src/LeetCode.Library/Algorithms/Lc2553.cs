namespace LeetCode.Library.Algorithms;

public class Lc2553Solution {
    public int[] SeparateDigits(int[] nums) {
        int n = nums.Length;
        List<int> ans = [];
        for (int i = n - 1; i >= 0; i--) {
            int current = nums[i];
            while (current > 0) {
                ans.Add(current % 10);
                current /= 10;
            }
        }
        ans.Reverse();
        return [.. ans];
    }
}