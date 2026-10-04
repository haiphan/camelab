namespace LeetCode.Library.Algorithms;

public class Lc678Solution {
    public bool CheckValidString(string s) {
        int lmax = 0;
        int lmin = 0;
        int n = s.Length;
        for (int i = 0; i < n; i++) {
            if (s[i] == '(') {
                lmax++;
                lmin++;
            }
            if (s[i] == ')') {
                lmax--;
                lmin = Math.Max(lmin - 1, 0);
            }
            if (s[i] == '*') {
                lmax++;
                lmin = Math.Max(lmin - 1, 0);
            }
            if (lmax < 0) return false;
        }
        return lmin == 0;
    }
}