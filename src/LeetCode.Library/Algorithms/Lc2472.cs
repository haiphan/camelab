namespace LeetCode.Library.Algorithms;

public class Lc2472Solution {
    private bool IsPalindrome(string s, int start, int end) {
        while (start < end) {
            if (s[start] != s[end]) return false;
            start++;
            end--;
        }
        return true;
    }
    public int MaxPalindromes(string s, int k) {
        var n = s.Length;
        var count = 0;
        var startMin = 0;

        for (var end = 0; end < n; end++) {
            var start = end - k + 1;
            if (start >= startMin && IsPalindrome(s, start, end)) {
                count++;
                startMin = end + 1;
                continue;
            }

            start--;
            if (start >= startMin && IsPalindrome(s, start, end)) {
                count++;
                startMin = end + 1;
            }
        }

        return count;
    }
}