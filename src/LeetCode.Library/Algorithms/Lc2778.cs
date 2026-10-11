namespace LeetCode.Library.Algorithms;

public class Lc2778Solution {
    public int SumOfSquares(int[] nums) {
        int sum = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            int j = i + 1;
            if (n % j == 0)
            {
                sum += nums[i] * nums[i];
            }
        }
        return sum;
    }
}