namespace LeetCode.Library.Algorithms;

public class Lc3129Solution {
    public long[] fact = [];
    public long[] invFact = [];
    public int mod = 1000000007;
    public long Pow(long a, long b) {
        long res = 1;
        while (b > 0) {
            if ((b & 1) == 1) {
                res = res * a % mod;
            }
            a = a * a % mod;
            b >>= 1;
        }
        return res;
    }
    public void FillFact(int n) {
        fact = new long[n + 1];
        invFact = new long[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++) {
            fact[i] = fact[i - 1] * i % mod;
        }
        invFact[n] = Pow(fact[n], mod - 2);
        for (int i = n - 1; i >= 0; i--) {
            invFact[i] = invFact[i + 1] * (i + 1) % mod;
        }
    }
    public long C(int n, int k) {
        if (k > n || k < 0) {
            return 0;
        }
        return fact[n] * invFact[k] % mod * invFact[n - k] % mod;
    }
    public long CountWays(int n, int k, int l) {
        if (k > n || k < 0) {
            return 0;
        }
        long ans = 0;
        int maxJ = (n - k) / l;
        for (int j = 0; j <= maxJ; j++) {
            long ways = C(n - 1 - j * l , k - 1) * C(k, j) % mod;
            if (j % 2 == 0) {
                ans = (ans + ways) % mod;
            } else {
                ans = (ans - ways + mod) % mod;
            }
        }
        return ans;
    }
    public int NumberOfStableArrays(int zero, int one, int limit) {
        int n = zero + one;
        FillFact(n);
        int maxK = Math.Min(zero, one + 1);
        long[] fOne = new long[maxK + 2];
        for (int k = 1; k <= maxK + 1; k++) {
            fOne[k] = CountWays(one, k, limit);
        }
        long ans = 0;
        for (int k = 1; k <= maxK; k++) {
            long fZero = CountWays(zero, k, limit);
            if (fZero == 0) {
                continue;
            }
            long sumFOne = (fOne[k - 1] + 2 * fOne[k] + fOne[k + 1]) % mod;
            ans = (ans + fZero * sumFOne) % mod;
        }
        return (int)ans;
    }
}