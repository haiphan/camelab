namespace LeetCode.Library.Algorithms;

public class Lc3090Solution {
    public int MaximumLengthSubstring(string s) {
        int l = 0;
        int[] count = new int[26];
        int ans = 0;
        for (int r = 0; r < s.Length; r++) {
            int rightChar = s[r] - 'a';
            count[rightChar]++;
            while (count[rightChar] > 2) {
                count[s[l] - 'a']--;
                l++;
            }
            ans = Math.Max(ans, r - l + 1);
            if (ans >= s.Length - l) {
                return ans;
            }
        }
        return ans;
    }
}