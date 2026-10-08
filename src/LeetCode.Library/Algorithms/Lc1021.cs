namespace LeetCode.Library.Algorithms;

public class Lc1021Solution {
    public string RemoveOuterParentheses(string s) {
        var sb = new System.Text.StringBuilder();
        var open = 0;
        foreach (var c in s) {
            if (c == '(') {
                if (open > 0)
                {
                    sb.Append(c);
                }
                open++;
            } else if (c == ')') {
                open--;
                if (open > 0)
                {
                    sb.Append(c);
                }
            }
        }
        return sb.ToString();
    }
}