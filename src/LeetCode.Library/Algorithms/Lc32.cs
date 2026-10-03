namespace LeetCode.Library.Algorithms;

public class Lc32Solution {
    public int LongestValidParentheses(string s) {
        int maxLen = 0, open = 0, close = 0;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') open++; else close++;
            if (open == close) {
                maxLen = Math.Max(maxLen, 2 * close);
            } else if (close > open) {
                open = close = 0;
            }
        }
        open = close = 0;
        // Right-to-left pass catches runs with excess unmatched '(' that the left-to-right pass resets away.
        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] == '(') open++; else close++;
            if (open == close) {
                maxLen = Math.Max(maxLen, 2 * open);
            } else if (open > close) {
                open = close = 0;
            }
        }
        return maxLen;
    }
}