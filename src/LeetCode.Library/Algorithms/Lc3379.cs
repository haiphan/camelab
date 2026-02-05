namespace LeetCode.Library.Algorithms;

public class Lc3379Solution {
    public int[] ConstructTransformedArray(int[] nums) {
        int n = nums.Length;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++) {
            int step = nums[i] % n;
            int j = (i + step + n) % n ;
            ans[i] = nums[j];
        }
        return ans;
    }
}