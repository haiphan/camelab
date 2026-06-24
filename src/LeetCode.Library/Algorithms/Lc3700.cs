namespace LeetCode.Library.Algorithms;

public class Lc3700Solution {
    public int ZigZagArrays(int n, int l, int r) {
        const int MOD = 1000000007;
        int sz = r - l + 1;
        if (n <= 0 || sz <= 0) {
            return 0;
        }

        long[][] BuildLessThanTransition() {
            long[][] mat = new long[sz][];
            for (int i = 0; i < sz; i++) {
                mat[i] = new long[sz];
                for (int j = 0; j < i; j++) {
                    mat[i][j] = 1;
                }
            }
            return mat;
        }

        long[][] BuildGreaterThanTransition() {
            long[][] mat = new long[sz][];
            for (int i = 0; i < sz; i++) {
                mat[i] = new long[sz];
                for (int j = i + 1; j < sz; j++) {
                    mat[i][j] = 1;
                }
            }
            return mat;
        }

        long[][] Mul(long[][] a, long[][] b) {
            long[][] c = new long[sz][];
            for (int i = 0; i < sz; i++) {
                c[i] = new long[sz];
                for (int k = 0; k < sz; k++) {
                    long aik = a[i][k];
                    if (aik == 0) {
                        continue;
                    }
                    for (int j = 0; j < sz; j++) {
                        c[i][j] = (c[i][j] + aik * b[k][j]) % MOD;
                    }
                }
            }
            return c;
        }

        long[][] Identity() {
            long[][] id = new long[sz][];
            for (int i = 0; i < sz; i++) {
                id[i] = new long[sz];
                id[i][i] = 1;
            }
            return id;
        }

        long[][] Pow(long[][] baseMat, int exp) {
            long[][] result = Identity();
            long[][] cur = baseMat;
            int e = exp;
            while (e > 0) {
                if ((e & 1) != 0) {
                    result = Mul(result, cur);
                }
                cur = Mul(cur, cur);
                e >>= 1;
            }
            return result;
        }

        long[] MulVec(long[][] mat, long[] vec) {
            long[] outVec = new long[sz];
            for (int i = 0; i < sz; i++) {
                long sum = 0;
                for (int j = 0; j < sz; j++) {
                    if (mat[i][j] == 0 || vec[j] == 0) {
                        continue;
                    }
                    sum = (sum + mat[i][j] * vec[j]) % MOD;
                }
                outVec[i] = sum;
            }
            return outVec;
        }

        long[] dp = new long[sz];
        for (int i = 0; i < sz; i++) {
            dp[i] = 1;
        }

        long[][] less = BuildLessThanTransition();
        long[][] greater = BuildGreaterThanTransition();
        long[][] pair = Mul(greater, less); // Two transitions: "<" then ">".

        if ((n & 1) == 1) {
            int pairs = (n - 1) / 2;
            dp = MulVec(Pow(pair, pairs), dp);
        }
        else {
            int pairs = (n - 2) / 2;
            dp = MulVec(Pow(pair, pairs), dp);
            dp = MulVec(less, dp);
        }

        long ans = 0;
        for (int i = 0; i < sz; i++) {
            ans = (ans + dp[i]) % MOD;
        }

        return (int)((ans << 1) % MOD);
    }
}