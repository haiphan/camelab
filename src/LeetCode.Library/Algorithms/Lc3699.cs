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
            Array.Reverse(dp);
            int s = 0;
            for (int j = 0; j < sz; j++)
            {
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