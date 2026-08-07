namespace LeetCode.Library.Algorithms;

public class Lc3348Solution {
    private const int Inf = 1_000_000_000;

    private static readonly int[] Pow2 = [0, 0, 1, 0, 2, 0, 1, 0, 3, 0];
    private static readonly int[] Pow3 = [0, 0, 0, 1, 0, 0, 1, 0, 0, 2];
    private static readonly int[] Pow5 = [0, 0, 0, 0, 0, 1, 0, 0, 0, 0];
    private static readonly int[] Pow7 = [0, 0, 0, 0, 0, 0, 0, 1, 0, 0];

    private static int[,] BuildMinDigitsFor23(int need2, int need3) {
        int[,] dp = new int[need2 + 1, need3 + 1];
        for (int i = 0; i <= need2; i++) {
            for (int j = 0; j <= need3; j++) {
                dp[i, j] = Inf;
            }
        }

        dp[0, 0] = 0;
        (int d2, int d3)[] options = [(1, 0), (0, 1), (2, 0), (1, 1), (3, 0), (0, 2)];

        for (int i = 0; i <= need2; i++) {
            for (int j = 0; j <= need3; j++) {
                int cur = dp[i, j];
                if (cur == Inf) {
                    continue;
                }

                foreach (var (d2, d3) in options) {
                    int ni = Math.Min(need2, i + d2);
                    int nj = Math.Min(need3, j + d3);
                    if (cur + 1 < dp[ni, nj]) {
                        dp[ni, nj] = cur + 1;
                    }
                }
            }
        }

        return dp;
    }

    private static bool CanFill(int len, int need2, int need3, int need5, int need7, int[,] min23) {
        int fixedSlots = need5 + need7;
        if (len < fixedSlots) {
            return false;
        }

        return min23[need2, need3] <= len - fixedSlots;
    }

    private static void FillSmallestSuffix(Span<char> ans, int need2, int need3, int need5, int need7, int[,] min23) {
        for (int i = 0; i < ans.Length; i++) {
            for (int digit = 1; digit <= 9; digit++) {
                int n2 = Math.Max(0, need2 - Pow2[digit]);
                int n3 = Math.Max(0, need3 - Pow3[digit]);
                int n5 = Math.Max(0, need5 - Pow5[digit]);
                int n7 = Math.Max(0, need7 - Pow7[digit]);

                if (!CanFill(ans.Length - i - 1, n2, n3, n5, n7, min23)) {
                    continue;
                }

                ans[i] = (char)('0' + digit);
                need2 = n2;
                need3 = n3;
                need5 = n5;
                need7 = n7;
                break;
            }
        }
    }

    private static bool Factorize(long t, out int need2, out int need3, out int need5, out int need7) {
        need2 = 0;
        need3 = 0;
        need5 = 0;
        need7 = 0;

        while (t % 2 == 0) {
            need2++;
            t /= 2;
        }
        while (t % 3 == 0) {
            need3++;
            t /= 3;
        }
        while (t % 5 == 0) {
            need5++;
            t /= 5;
        }
        while (t % 7 == 0) {
            need7++;
            t /= 7;
        }

        return t == 1;
    }

    public string SmallestNumber(string num, long t) {
        if (!Factorize(t, out int need2, out int need3, out int need5, out int need7)) {
            return "-1";
        }

        int n = num.Length;
        int[,] min23 = BuildMinDigitsFor23(need2, need3);

        int total2 = 0;
        int total3 = 0;
        int total5 = 0;
        int total7 = 0;
        int totalZero = 0;
        for (int i = 0; i < n; i++) {
            int digit = num[i] - '0';
            total2 += Pow2[digit];
            total3 += Pow3[digit];
            total5 += Pow5[digit];
            total7 += Pow7[digit];
            if (digit == 0) {
                totalZero++;
            }
        }

        if (totalZero == 0 &&
            total2 >= need2 &&
            total3 >= need3 &&
            total5 >= need5 &&
            total7 >= need7) {
            return num;
        }

        int pre2 = total2;
        int pre3 = total3;
        int pre5 = total5;
        int pre7 = total7;
        int preZero = totalZero;

        for (int i = n - 1; i >= 0; i--) {
            int current = num[i] - '0';
            pre2 -= Pow2[current];
            pre3 -= Pow3[current];
            pre5 -= Pow5[current];
            pre7 -= Pow7[current];
            if (current == 0) {
                preZero--;
            }

            if (preZero > 0) {
                continue;
            }

            int start = Math.Max(1, current + 1);
            for (int digit = start; digit <= 9; digit++) {
                int rem2 = Math.Max(0, need2 - (pre2 + Pow2[digit]));
                int rem3 = Math.Max(0, need3 - (pre3 + Pow3[digit]));
                int rem5 = Math.Max(0, need5 - (pre5 + Pow5[digit]));
                int rem7 = Math.Max(0, need7 - (pre7 + Pow7[digit]));
                int suffixLen = n - i - 1;

                if (!CanFill(suffixLen, rem2, rem3, rem5, rem7, min23)) {
                    continue;
                }

                char[] ans = new char[n];
                num.AsSpan(0, i).CopyTo(ans);
                ans[i] = (char)('0' + digit);
                FillSmallestSuffix(ans.AsSpan(i + 1), rem2, rem3, rem5, rem7, min23);
                return new string(ans);
            }
        }

        int minLen = need5 + need7 + min23[need2, need3];
        int targetLen = Math.Max(n + 1, minLen);
        char[] result = new char[targetLen];
        FillSmallestSuffix(result, need2, need3, need5, need7, min23);
        return new string(result);
    }
}