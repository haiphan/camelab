namespace LeetCode.Library.Algorithms;

public class Lc940Solution {
    public int DistinctSubseqII(string s) {
        int MOD = 1_000_000_007;
        int n = s.Length;
        var dp = new int[n + 1];
        dp[0] = 1;
        var last = new int[26];
        for (int i = 1; i <= n; i++) {
            int c = s[i - 1] - 'a';
            dp[i] = (2 * dp[i - 1]) % MOD;
            if (last[c] > 0) dp[i] = (dp[i] - dp[last[c] - 1] + MOD) % MOD;
            last[c] = i;
        }
        return (dp[n] - 1 + MOD) % MOD;
    }
}