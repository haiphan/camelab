namespace LeetCode.Library.Algorithms;

public class Lc32Solution {
    public int LongestValidParentheses(string s) {
        int n = s.Length;
        int maxLen = 0;
        var dp = new int[n];
        for (int i = 1; i < n; i++) {
            if (s[i] != ')') continue;
            // dp[i - 1] is 0 when s[i - 1] == '(', so this also covers that case directly.
            var openIdx = i - dp[i - 1] - 1;
            if (openIdx >= 0 && s[openIdx] == '(') {
                dp[i] = dp[i - 1] + 2 + (openIdx >= 1 ? dp[openIdx - 1] : 0);
            }
            maxLen = Math.Max(maxLen, dp[i]);
        }
        return maxLen;
    }
}