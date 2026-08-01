namespace LeetCode.Library.Algorithms;

public class Lc486Solution {
    public bool PredictTheWinner(int[] nums) {
        int n = nums.Length;
        // dp[i, j] represents the maximum score difference the current player can achieve over the other player for the subarray nums[i..j]
        int[,] dp = new int[n, n];

        for (int i = 0; i < n; i++) {
            dp[i, i] = nums[i];
        }

        for (int len = 2; len <= n; len++) {
            for (int i = 0; i <= n - len; i++) {
                int j = i + len - 1;
                dp[i, j] = Math.Max(nums[i] - dp[i + 1, j], nums[j] - dp[i, j - 1]);
            }
        }

        return dp[0, n - 1] >= 0;
    }
}