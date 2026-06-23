namespace LeetCode.Library.Algorithms;

public class Lc3699Solution {
    public int ZigZagArrays(int n, int l, int r) {
        int MOD = 1000000007;
        int sz = r - l + 1;
        int[] dp = new int[sz];
        for (int i = 0; i < sz; i++) {
            dp[i] = 1;
        }
        for (int i = 2; i <= n; i++)
        {
            int s = 0;
            int rev = i & 1;
            for (int k = 0; k < sz; k++)
            {
                int j = k + rev * (sz - 1 - (k << 1));
                int temp = dp[j];
                dp[j] = s;
                s = (s + temp) % MOD;
            }
        }
        int ans = 0;
        for (int i = 0; i < sz; i++)
        {
            ans = (ans + dp[i]) % MOD;
        }
        return (ans << 1) % MOD;
    }
}