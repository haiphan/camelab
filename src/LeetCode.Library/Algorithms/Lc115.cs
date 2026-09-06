namespace LeetCode.Library.Algorithms;

public class Lc115Solution {
    public int NumDistinct(string s, string t) {
        int m = s.Length, n = t.Length;
        if (m < n) return 0;
        var dp = new int[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= m; i++) {
            int i1 = i - 1;
            // dp[j] is 0 for j > i, so start below that bound
            for (int j = Math.Min(i, n); j >= 1; j--) {
                if (s[i1] == t[j - 1]) dp[j] += dp[j - 1];
            }
        }
        return dp[n];
    }
}