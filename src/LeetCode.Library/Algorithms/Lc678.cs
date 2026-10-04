namespace LeetCode.Library.Algorithms;

public class Lc678Solution {
    public bool CheckValidString(string s) {
        int lmax = 0;
        int lmin = 0;
        foreach (var c in s) {
            if (c == '(') {
                lmax++;
                lmin++;
            } else if (c == ')') {
                lmax--;
                lmin = Math.Max(lmin - 1, 0);
            } else {
                lmax++;
                lmin = Math.Max(lmin - 1, 0);
            }
            if (lmax < 0)
            {
                return false;
            }
        }
        return lmin == 0;
    }
}