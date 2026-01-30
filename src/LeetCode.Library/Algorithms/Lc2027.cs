namespace LeetCode.Library.Algorithms;

public class Lc2027Solution {
    public int MinimumMoves(string s) {
        int n = s.Length;
        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (s[i] == 'X') {
                ans++;
                i += 2;
            }
        }
        return ans;
    }
}