namespace LeetCode.Library.Algorithms;

public class Lc1461Solution {
    public bool HasAllCodes(string s, int k) {
        int m = 1 << k;
        int mask = m - 1;
        int n = s.Length;
        if (n - k + 1 < m) {
            return false;
        }
        bool[] cm = new bool[m];
        int r = m;
        int cur = 0;
        for (int i = 0; i < k; i++) {
            cur = (cur << 1) | (s[i] & 1);
        }
        cm[cur] = true;
        r--;
        for (int i = k; i < n; i++) {
            if (n - i < r) return false;
            cur = ((cur << 1) | (s[i] & 1)) & mask;
            if (!cm[cur]) {
                r--;
                if (r == 0) return true;
            }
            cm[cur] = true;
        }
        return r == 0;
    }
}