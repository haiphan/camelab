namespace LeetCode.Library.Algorithms;

using System.Text;

public class Lc301Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        var left = 0;
        var right = 0;
        foreach (var c in s) {
            if (c == '(') {
                left++;
            } else if (c == ')') {
                if (left > 0) left--; else right++;
            }
        }

        var result = new List<string>();
        Dfs(new StringBuilder(s), 0, left, right, 0, result);
        return result;
    }

    private static void Dfs(StringBuilder sb, int start, int left, int right, int open, List<string> result) {
        // Not enough characters left from `start` onward to perform the remaining removals.
        if (sb.Length - start < left + right) return;

        var balance = open;
        for (int i = start; i < sb.Length; i++) {
            var c = sb[i];
            // Skip duplicate brackets at this position so the same resulting string isn't produced twice.
            if (i == start || sb[i] != sb[i - 1]) {
                if (right > 0 && c == ')') {
                    sb.Remove(i, 1);
                    Dfs(sb, i, left, right - 1, balance, result);
                    sb.Insert(i, c);
                }
                if (left > 0 && c == '(') {
                    sb.Remove(i, 1);
                    Dfs(sb, i, left - 1, right, balance, result);
                    sb.Insert(i, c);
                }
            }

            // Track balance for the "kept" path; a ')' with no match here can never be fixed by later choices.
            if (c == '(') {
                balance++;
            } else if (c == ')' && --balance < 0) {
                return;
            }
        }

        if (left == 0 && right == 0 && balance == 0) {
            result.Add(sb.ToString());
        }
    }
}