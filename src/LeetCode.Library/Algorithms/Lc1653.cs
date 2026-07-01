namespace LeetCode.Library.Algorithms;

public class Lc1653Solution {
    public int MinimumDeletions(string s) {
        int n = s.Length;
        int ans = 0;
        int cb = 0;
        for (int i = 0; i < n; i++) {
            if (s[i] == 'b') {
                cb++;
            } else if (cb > 0) {
                ans++;
                cb--;
            }
        }
        return ans;
    }
}