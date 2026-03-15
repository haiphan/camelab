namespace LeetCode.Library.Algorithms;

public static class ArithmeticUtils {
    public static int NormalizeMod(int a, int m) {
        if (m <= 0) {
            throw new ArgumentOutOfRangeException(nameof(m), "Modulus must be positive.");
        }

        int r = a % m;
        return r < 0 ? r + m : r;
    }

    public static int PowMod(int a, int b, int m) {
        if (b < 0) {
            throw new ArgumentOutOfRangeException(nameof(b), "Exponent must be non-negative.");
        }
        if (m <= 0) {
            throw new ArgumentOutOfRangeException(nameof(m), "Modulus must be positive.");
        }

        long baseValue = NormalizeMod(a, m);
        long result = 1;
        int exp = b;

        while (exp > 0) {
            long bit = exp & 1;
            long factor = 1 + (baseValue - 1) * bit;
            result = (result * factor) % m;

            baseValue = (baseValue * baseValue) % m;
            exp >>= 1;
        }

        return (int)result;
    }

    public static int Gcd(int a, int b) {
        int x = Math.Abs(a);
        int y = Math.Abs(b);

        while (y != 0) {
            int t = x % y;
            x = y;
            y = t;
        }

        return x;
    }

    public static long Lcm(int a, int b) {
        if (a == 0 || b == 0) {
            return 0;
        }

        return (long)Math.Abs(a / Gcd(a, b)) * Math.Abs((long)b);
    }
}
