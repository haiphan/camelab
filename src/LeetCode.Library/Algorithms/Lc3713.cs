namespace LeetCode.Library.Algorithms;

public class Lc3713Solution {
    public int LongestBalanced(string s) {
        int n = s.Length;
        int ans = 1;
        for (int i = 0; i <n; i++) {
            if (n - i <= ans) break;
            int cnt = 0;
            int maxc = 0;
            int[] cm = new int[26];
            for (int j = i; j < n; j++) {
                int code = s[j] - 'a';
                if (cm[code] == 0) cnt++;
                cm[code]++;
                maxc = Math.Max(maxc, cm[code]);
                int ws = j - i + 1;
                if (maxc * cnt == ws) {
                    ans = Math.Max(ans, ws);
                }
            }
        }
        return ans;
    }
}