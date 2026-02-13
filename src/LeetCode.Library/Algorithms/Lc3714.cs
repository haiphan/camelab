namespace LeetCode.Library.Algorithms;

public class Lc3714Solution {
    public int ans = 1;
    public int[] cntABC = new int[3];
    public int OneChar(string s) {
        int cnt = 1;
        int n = s.Length;
        for (int i = 1; i < n; i++) {
            if (cnt + n - i <= ans) {
                break;
            }
            if (s[i] == s[i - 1]) {
                cnt++;
            } else {
                cnt = 1;
            }
            ans = Math.Max(ans, cnt);
        }
        return ans;
    }
    public int TwoChars(string s, char c1, char c2) {
        int ub = Math.Min(cntABC[c1 - 'a'], cntABC[c2 - 'a']) * 2;
        if (ub <= ans) {
            return ans;
        }
        int n = s.Length;
        Dictionary<int, int> pos = new(n);
        pos[0] = -1;
        int delta = 0;
        for (int i = 0; i < n; i++) {
            if (s[i] != c1 && s[i] != c2) {
                if (n - (i + 1) <= ans) return ans;
                pos.Clear();
                pos[0] = i;
                delta = 0;
                continue;
            }
            if (s[i] == c1) {
                delta++;
            } else {
                delta--;
            }
            if (pos.TryGetValue(delta, out int p)) {
                ans = Math.Max(ans, i - p);
            } else {
                pos[delta] = i;
            }
        }
        return ans;
    }
    public int ThreeChars(string s) {
        int ub = 3 * Math.Min(cntABC[0], Math.Min(cntABC[1], cntABC[2]));
        if (ub <= ans) {
            return ans;
        }
        int n = s.Length;
        int[] cnt = new int[3];
        Dictionary<(int, int), int>pos = new(n);
        pos[(0, 0)] = -1;

        for (int i = 0; i < n; i++) {
            cnt[s[i] - 'a']++;
            (int, int) key = (cnt[1] - cnt[0], cnt[2] - cnt[0]);
            if (pos.TryGetValue(key, out int p)) {
                ans = Math.Max(ans, i - p);
            } else {
                pos[key] = i;
            }
        }
        return ans;
    }
    public int LongestBalanced(string s) {
        int n = s.Length;
        for (int i = 0; i < n; i++) {
            cntABC[s[i] - 'a']++;
        }
        int v = OneChar(s);
        v = Math.Max(v, TwoChars(s, 'a', 'b'));
        v = Math.Max(v, TwoChars(s, 'a', 'c'));
        v = Math.Max(v, TwoChars(s, 'b', 'c'));
        v = Math.Max(v, ThreeChars(s));
        return v;
    }
}