namespace LeetCode.Library.Algorithms;

public class Lc3518Solution {
    private const int Big = 1_000_001;
    private static readonly int[,] Comb = BuildComb();

    public string SmallestPalindrome(string s, int k) {
        int n = s.Length;
        int half = n / 2;
        int[] counts = new int[26];
        char middle = '\0';

        foreach (char ch in s) {
            counts[ch - 'a']++;
        }

        for (int i = 0; i < 26; i++) {
            if ((counts[i] & 1) == 1) {
                middle = (char)('a' + i);
            }

            counts[i] /= 2;
        }

        char[] result = new char[n];
        int total = CountPermutations(counts, half);
        if (total < k) {
            return string.Empty;
        }

        int left = 0;
        for (int i = 0; i < half; i++) {
            for (int j = 0; j < 26; j++) {
                if (counts[j] == 0) {
                    continue;
                }
                counts[j]--;
                char c = (char)(j + 'a');
                int newTotal = CountPermutations(counts, half - i - 1);
                if (newTotal >= k) {
                    result[left] = c;
                    result[n - left - 1] = c;
                    left++;
                    break;
                } else {
                    k -= newTotal;
                    counts[j]++;
                }
            }
        }

        if (n % 2 == 1) {
            result[half] = middle;
        }

        return new string(result);
    }

    private static int CountPermutations(int[] counts, int sz) {
        if (sz <= 1) {
            return 1;
        }

        long ways = 1;

        foreach(int count in counts) {
            if (count == 0) {
                continue;
            }

            ways *= Cnk(sz, count);
            if (ways >= Big) {
                return Big;
            }

            sz -= count;
        }

        return (int)ways;
    }

    private static int Cnk(int n, int k) {
        if (k > n - k) {
            k = n - k;
        }

        if (k == 0) {
            return 1;
        }

        if (n <= 24) {
            return Comb[n, k];
        }

        if (k == 1) {
            return n;
        }

        long result = 1;
        for (int i = 1; i <= k; i++) {
            result = result * (n - k + i) / i;
            if (result >= Big) {
                return Big;
            }
        }

        return (int)result;
    }

    private static int[,] BuildComb() {
        int[,] comb = new int[25, 25];
        comb[0, 0] = 1;

        for (int n = 1; n <= 24; n++) {
            comb[n, 0] = 1;
            comb[n, n] = 1;

            for (int k = 1; k < n; k++) {
                comb[n, k] = Math.Min(Big, comb[n - 1, k - 1] + comb[n - 1, k]);
            }
        }

        return comb;
    }
}