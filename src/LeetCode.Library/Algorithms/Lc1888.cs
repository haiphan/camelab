namespace LeetCode.Library.Algorithms;

public class Lc1888Solution {
    public int MinFlips(string s) {
        int n = s.Length;
        int c1 = 0;
        for (int i = 0; i < n; i++) {
            int flip = i & 1;
            c1 += 1 - ((s[i] - '0') ^ flip);
        }
        int c0 = n - c1;
        int ans = Math.Min(c0, c1);
        if (n % 2 == 0) {
            return ans;
        }
        int p1 = 1 - (s[0] - '0');
        for (int i = 1; i < n; i++) {
            int flip = i & 1;
            p1 += 1 - ((s[i] - '0') ^ flip);
            int p0 = i + 1 - p1;
            int s0 = c0 - p0;
            int s1 = c1 - p1;
            ans = Math.Min(ans, s0 + p1);
            ans = Math.Min(ans, s1 + p0);
        }
        return ans;
    }
}