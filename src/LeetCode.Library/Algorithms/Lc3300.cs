namespace LeetCode.Library.Algorithms;

public class Lc3300Solution {
    public int MinElement(int[] nums) {
        int n = nums.Length;
        int ans = 9 * 5;
        for (int i = 0; i < n; i++) {
            int num = nums[i];
            int sumDigits = 0;
            while (num > 0) {
                sumDigits += num % 10;
                num /= 10;
            }
            ans = Math.Min(ans, sumDigits);
            if (ans == 1) {
                break;
            }
        }
        return ans;
    }
}