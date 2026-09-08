namespace LeetCode.Library.Algorithms;

public class Lc940Solution {
    public int DistinctSubseqII(string s) {
        int MOD = 1_000_000_007;
        int n = s.Length;
        // dp[i] represents the number of distinct subsequences of s[0..i-1]
        var dp = new int[n + 1];
        dp[0] = 1;
        var last = new int[26];
        for (int i = 1; i <= n; i++) {
            int c = s[i - 1] - 'a';
            dp[i] = (2 * dp[i - 1]) % MOD;
            // If the character has appeared before, subtract the number of subsequences
            // that ended with the previous occurrence of this character.
            if (last[c] > 0) dp[i] = (dp[i] - dp[last[c] - 1] + MOD) % MOD;
            last[c] = i;
        }
        // The final result is the number of distinct subsequences of the entire string, excluding the empty subsequence.
        return (dp[n] - 1 + MOD) % MOD;
    }
}