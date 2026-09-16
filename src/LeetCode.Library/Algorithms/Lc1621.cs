namespace LeetCode.Library.Algorithms;

public class Lc1621Solution {
    private const int MOD = 1_000_000_007;
    private int ModPow(int baseValue, int exponent) {
        long result = 1;
        long baseLong = baseValue;
        while (exponent > 0) {
            if ((exponent & 1) == 1) {
                result = (result * baseLong) % MOD;
            }
            baseLong = (baseLong * baseLong) % MOD;
            exponent >>= 1;
        }
        return (int)result;
    }
    public int NumberOfSets(int n, int k) {
        long N = n + k - 1;
        long R = 2 * k;
        R = Math.Min(R, N - R);
        long numerator = 1;
        long denominator = 1;
        for (long i = 1; i <= R; i++) {
            numerator = (numerator * (N - i + 1)) % MOD;
            denominator = (denominator * i) % MOD;
        }
        return (int)(numerator * ModPow((int)denominator, MOD - 2) % MOD);
    }
}