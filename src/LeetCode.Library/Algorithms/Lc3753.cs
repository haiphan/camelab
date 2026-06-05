namespace LeetCode.Library.Algorithms;

public class Lc3753Solution {
    private const int DigitStates = 11; // -1..9 mapped to 0..10

    private static bool IsPeakOrValley(int left, int mid, int right) {
        return (mid > left && mid > right) || (mid < left && mid < right);
    }

    private static long TotalWavinessInRange(long num1, long num2) {
        if (num2 < num1) {
            return 0;
        }

        string lowDigits = Math.Max(0, num1).ToString();
        string highDigits = num2.ToString();
        int length = highDigits.Length;
        lowDigits = lowDigits.PadLeft(length, '0');

        long[,,,] waysMemo = new long[length + 1, 2, DigitStates, DigitStates];
        long[,,,] sumMemo = new long[length + 1, 2, DigitStates, DigitStates];
        bool[,,,] seen = new bool[length + 1, 2, DigitStates, DigitStates];

        (long ways, long wavinessSum) Dfs(int pos, bool lowTight, bool highTight, bool started, int last1, int last2) {
            if (pos == length) {
                return (1L, 0L);
            }

            int startedIndex = started ? 1 : 0;
            int last1Index = last1 + 1;
            int last2Index = last2 + 1;

            if (!lowTight && !highTight && seen[pos, startedIndex, last1Index, last2Index]) {
                return (waysMemo[pos, startedIndex, last1Index, last2Index], sumMemo[pos, startedIndex, last1Index, last2Index]);
            }

            int minDigit = lowTight ? lowDigits[pos] - '0' : 0;
            int maxDigit = highTight ? highDigits[pos] - '0' : 9;
            long totalWays = 0;
            long totalSum = 0;

            for (int digit = minDigit; digit <= maxDigit; digit++) {
                bool nextLowTight = lowTight && digit == minDigit;
                bool nextHighTight = highTight && digit == maxDigit;
                bool nextStarted = started || digit != 0;
                int nextLast1 = last1;
                int nextLast2 = last2;
                long add = 0;

                if (nextStarted) {
                    if (!started) {
                        nextLast1 = digit;
                        nextLast2 = -1;
                    } else {
                        if (last2 != -1 && IsPeakOrValley(last2, last1, digit)) {
                            add = 1;
                        }

                        nextLast2 = last1;
                        nextLast1 = digit;
                    }
                }

                var child = Dfs(pos + 1, nextLowTight, nextHighTight, nextStarted, nextLast1, nextLast2);
                totalWays += child.ways;
                totalSum += child.wavinessSum + add * child.ways;
            }

            if (!lowTight && !highTight) {
                seen[pos, startedIndex, last1Index, last2Index] = true;
                waysMemo[pos, startedIndex, last1Index, last2Index] = totalWays;
                sumMemo[pos, startedIndex, last1Index, last2Index] = totalSum;
            }

            return (totalWays, totalSum);
        }

        return Dfs(0, true, true, false, -1, -1).wavinessSum;
    }

    public long TotalWaviness(long num1, long num2) {
        return TotalWavinessInRange(num1, num2);
    }
}