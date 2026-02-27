namespace LeetCode.Library.Algorithms;

public class Lc3666Solution {
    public int MinOperations(string s, int k) {
        int n = s.Length;
        int nz = 0;
        for (int i = 0; i < n; i++) {
            if (s[i] == '0') {
                nz++;
            }
        }
        if (n == k) {
            if (nz == 0) {
                return 0;
            }
            if (nz == n) {
                return 1;
            }
            return -1;
        }
        int ans = int.MaxValue;
        if (nz % 2 == 0) {
            int m = Math.Max((nz + k - 1) / k, (nz + n - k - 1)/ (n - k));
            m += m & 1;
            ans = Math.Min(ans, m);
        }
        if ((nz % 2) == (k % 2)) {
            int m = Math.Max((nz + k - 1) / k, (n - nz + n - k - 1) / (n - k));
            m += 1 - (m & 1);
            ans = Math.Min(ans, m);
        }
        if (ans == int.MaxValue) {
            return -1;
        }
        return ans;
    }
}