namespace LeetCode.Library.Algorithms;

public class Lc3517Solution {
    public string SmallestPalindrome(string s) {
        int n = s.Length;
        int mid = n / 2;
        char[] chars = new char[n];
        Span<int> count = stackalloc int[26];
        foreach (char c in s) {
            count[c - 'a']++;
        }
        int l = 0, r = n - 1;
        for (int i = 0; i < 26; i++) {
            int pairs = count[i] / 2;
            char ch = (char)(i + 'a');
            for (int p = 0; p < pairs; p++) {
                chars[l++] = ch;
                chars[r--] = ch;
            }
            count[i] -= pairs * 2;
        }
        if ((n & 1) == 1) {
            chars[mid] = s[mid];
        }
        return new string(chars);
    }
}