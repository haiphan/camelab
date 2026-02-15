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
        int[] pos = new int[2 * n + 1];
        int[] mark = new int[2 * n + 1];
        int offset = n; // Offset to handle negative deltas
        int m = 1;
        pos[offset] = -1; // pos[0] = -1
        mark[offset] = m;
        int delta = 0;

        for (int i = 0; i < n; i++) {
            if (s[i] != c1 && s[i] != c2) {
                if (n - (i + 1) <= ans) return ans;
                m++;
                pos[offset] = i;
                mark[offset] = m;
                delta = 0;
                continue;
            }
            if (s[i] == c1) {
                delta++;
            } else {
                delta--;
            }
            int idx = offset + delta;
            if (mark[idx] == m) {
                ans = Math.Max(ans, i - pos[idx]);
            } else {
                pos[idx] = i;
                mark[idx] = m;
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

        // Create list of (upper_bound, action) and sort by upper_bound descending
        var candidates = new List<(int ub, Action action)>
        {
            (cntABC[0], () => OneChar(s)),
            (Math.Min(cntABC[0], cntABC[1]) * 2, () => TwoChars(s, 'a', 'b')),
            (Math.Min(cntABC[0], cntABC[2]) * 2, () => TwoChars(s, 'a', 'c')),
            (Math.Min(cntABC[1], cntABC[2]) * 2, () => TwoChars(s, 'b', 'c')),
            (3 * Math.Min(cntABC[0], Math.Min(cntABC[1], cntABC[2])), () => ThreeChars(s))
        };
        candidates.Sort((a, b) => b.ub.CompareTo(a.ub)); // Sort descending by upper bound

        foreach (var (_, action) in candidates) {
            action();
        }

        return ans;
    }
}