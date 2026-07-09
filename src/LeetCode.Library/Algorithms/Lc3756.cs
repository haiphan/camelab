namespace LeetCode.Library.Algorithms;

public class Lc3756Solution {
    public int[] SumAndMultiply(string s, int[][] queries) {
        const int mod = 1_000_000_007;

        int length = s.Length;
        int[] nonZeroPrefix = new int[length + 1];
        int[] sumPrefix = new int[length + 1];
        long[] prefixValue = new long[length + 1];
        long[] pow10 = new long[length + 1];
        pow10[0] = 1;

        for (int i = 0; i < length; i++) {
            int digit = s[i] - '0';
            sumPrefix[i + 1] = sumPrefix[i] + digit;
            nonZeroPrefix[i + 1] = nonZeroPrefix[i];
            pow10[i + 1] = (pow10[i] * 10) % mod;

            if (digit != 0) {
                nonZeroPrefix[i + 1]++;
                int filteredIndex = nonZeroPrefix[i + 1];
                prefixValue[filteredIndex] = (prefixValue[filteredIndex - 1] * 10 + digit) % mod;
            }
        }

        int[] result = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++) {
            int left = queries[i][0];
            int right = queries[i][1];

            int start = nonZeroPrefix[left];
            int endExclusive = nonZeroPrefix[right + 1];
            int count = endExclusive - start;

            if (count == 0) {
                result[i] = 0;
                continue;
            }

            long value = (prefixValue[endExclusive] - (prefixValue[start] * pow10[count] % mod) + mod) % mod;

            long sum = sumPrefix[right + 1] - sumPrefix[left];
            result[i] = (int)(value * sum % mod);
        }

        return result;
    }
}