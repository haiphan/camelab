namespace LeetCode.Library.Algorithms;

public class Lc696Solution {
    public int CountBinarySubstrings(string s) {
        int n = s.Length;
        int prev = 0, ans = 0;
        int i = 0;
        while (i < n) {
            int c = s[i];
            int j = i + 1;
            while (j < n && s[j] == c) {
                j++;
            }
            int cur = j - i;
            ans += Math.Min(prev, cur);
            i = j;
            prev = cur;
        }
        return ans;
    }
}