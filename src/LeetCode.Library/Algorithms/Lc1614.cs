namespace LeetCode.Library.Algorithms;

public class Lc1614Solution {
    public int MaxDepth(string s) {
        int maxDepth = 0, currentDepth = 0;
        foreach (var c in s)
        {
            if (c == '(')
            {
                currentDepth++;
            } else if (c == ')')
            {
                currentDepth--;
            }
            maxDepth = Math.Max(maxDepth, currentDepth);
        }
        return maxDepth;
    }
}