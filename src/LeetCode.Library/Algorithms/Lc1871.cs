namespace LeetCode.Library.Algorithms;

public class Lc1871Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        int n = s.Length;
        if (s[n - 1] == '1') {
            return false;
        }
        int last = n - 1;
        int maxI = 0;
        bool[] dp = new bool[n];
        dp[0] = true;
        for (int i = 0; i < n; i++) {
            if (!dp[i]) {
                continue;
            }
            int tmpMax = i + maxJump;
            int start = Math.Max(i + minJump, maxI + 1);
            int end = Math.Min(tmpMax, last);
            for (int j = start; j <= end; j++) {
                if (s[j] == '0') {
                    dp[j] = true;
                }
            }
            if (dp[last]) {
                return true;
            }
            maxI = Math.Max(maxI, tmpMax);
        }
        return false;
    }
}