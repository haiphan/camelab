namespace LeetCode.Library.Algorithms;

public class Lc3499Solution {
    public int MaxActiveSectionsAfterTrade(string s) {
        int n = s.Length;
        if (n < 3) {
            int shortOnes = 0;
            foreach (char c in s) {
                shortOnes += c - '0';
            }
            return shortOnes;
        }

        int ones = 0;
        int bestGain = 0;
        int i = 0;

        while (i < n && s[i] == '1') {
            ones++;
            i++;
        }

        if (i == n) {
            return ones;
        }

        int leftZeroCount = 0;
        while (i < n && s[i] == '0') {
            leftZeroCount++;
            i++;
        }

        if (i == n) {
            return ones;
        }

        while (i < n) {
            int oneCount = 0;
            while (i < n && s[i] == '1') {
                oneCount++;
                ones++;
                i++;
            }

            if (oneCount == 0) {
                break;
            }

            int rightZeroCount = 0;
            while (i < n && s[i] == '0') {
                rightZeroCount++;
                i++;
            }

            if (rightZeroCount == 0) {
                break;
            }

            bestGain = Math.Max(bestGain, leftZeroCount + rightZeroCount);
            leftZeroCount = rightZeroCount;
        }

        return ones + bestGain;
    }
}