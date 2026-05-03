namespace LeetCode.Library.Algorithms;

public class Lc788Solution {
    // Digits that are valid after rotation: 0, 1, 2, 5, 6, 8, 9
    private static readonly bool[] Valid = { true, true, true, false, false, true, true, false, true, true };
    // Digits that change to a different valid digit after rotation: 2, 5, 6, 9
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
            // for each length, we have 7 choices for each digit, but we need to exclude those that are all from {0, 1, 8}.
            // Total combinations for len digits: 7^len
            // Combinations that are not good (only 0, 1, 8): 3^len
            // For len-digit numbers, the first digit cannot be 0, so we have 6 choices for the first digit and 7 choices for the remaining (len - 1) digits.
            // numbers that have only 0, 1, 8: 2 choices for the first digit (1 or 8) and 3 choices for the remaining (len - 1) digits.
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
                // If the current digit is invalid, we cannot form any more valid numbers by adding more digits.
                prefixAllValid = false;
                break;
            }

            if (Changes[currentDigit]) {
                prefixHasChange = true;
            }
        }
        // If all digits of n are valid and at least one digit causes a change, then n itself is a good number.
        if (prefixAllValid && prefixHasChange) {
            total++;
        }

        return total;
    }

    public int RotatedDigits(int n) {
        return CountGoodUpTo(n);
    }
}