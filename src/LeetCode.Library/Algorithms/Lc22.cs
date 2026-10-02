namespace LeetCode.Library.Algorithms;

public class Lc22Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        int L = 2 * n;
        void Backtrack(string current, int open, int close) {
            if (current.Length == L) {
                result.Add(current);
                return;
            }
            if (open < n) Backtrack(current + "(", open + 1, close);
            if (close < open) Backtrack(current + ")", open, close + 1);
        }
        Backtrack("", 0, 0);
        return result;
    }
}