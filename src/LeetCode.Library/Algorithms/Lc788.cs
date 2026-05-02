namespace LeetCode.Library.Algorithms;

public class Lc788Solution {
    private static readonly bool[] Valid = { true, true, true, false, false, true, true, false, true, true };
    private static readonly bool[] Changes = { false, false, true, false, false, true, true, false, false, true };

    // Counts good numbers in [1, n] by digit combinatorics instead of checking every number.
    private static int CountGoodUpTo(int n) {
        if (n <= 0) {
            return 0;
        }

        var digits = n.ToString();
        int length = digits.Length;

        // Precompute powers used for free choices on remaining suffix positions.
        int[] pow7 = new int[length + 1];
        int[] pow3 = new int[length + 1];
        pow7[0] = 1;
        pow3[0] = 1;
        for (int i = 1; i <= length; i++) {
            pow7[i] = pow7[i - 1] * 7;
            pow3[i] = pow3[i - 1] * 3;
        }

        int total = 0;

        // Count good numbers with fewer digits than n.
        for (int len = 1; len < length; len++) {
            total += 6 * pow7[len - 1] - 2 * pow3[len - 1];
        }

        // Count good numbers with same length as n and <= n.
        bool prefixAllValid = true;
        bool prefixHasChange = false;

        for (int i = 0; i < length && prefixAllValid; i++) {
            int currentDigit = digits[i] - '0';
            int remaining = length - i - 1;

            for (int candidate = (i == 0 ? 1 : 0); candidate < currentDigit; candidate++) {
                if (!Valid[candidate]) {
                    continue;
                }

                if (prefixHasChange || Changes[candidate]) {
                    total += pow7[remaining];
                } else {
                    total += pow7[remaining] - pow3[remaining];
                }
            }

            if (!Valid[currentDigit]) {
                prefixAllValid = false;
                break;
            }

            if (Changes[currentDigit]) {
                prefixHasChange = true;
            }
        }

        if (prefixAllValid && prefixHasChange) {
            total++;
        }

        return total;
    }

    public int RotatedDigits(int n) {
        return CountGoodUpTo(n);
    }
}