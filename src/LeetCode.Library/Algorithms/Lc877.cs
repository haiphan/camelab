namespace LeetCode.Library.Algorithms;

public class Lc877Solution {
    public bool StoneGame(int[] piles) {
        int n = piles.Length;
        int[] dp = new int[n];
        for (int i = 0; i < n; i++) {
            dp[i] = piles[i];
        }
        for (int len = 2; len <= n; len++) {
            for (int i = 0; i <= n - len; i++) {
                int j = i + len - 1;
                dp[i] = Math.Max(piles[i] - dp[i + 1], piles[j] - dp[i]);
            }
        }
        return dp[0] > 0;
    }
}