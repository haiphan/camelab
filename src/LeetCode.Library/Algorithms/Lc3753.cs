namespace LeetCode.Library.Algorithms;

public class Lc3753Solution {
    private const int DigitStates = 11; // -1..9 mapped to 0..10
    private const long DirectScanThreshold = 2048;

    private static bool IsPeakOrValley(int left, int mid, int right) {
        return (mid > left && mid > right) || (mid < left && mid < right);
    }

    private static int GetWaviness(long num) {
        if (num < 100) {
            return 0;
        }

        int right = (int)(num % 10);
        num /= 10;
        int mid = (int)(num % 10);
        num /= 10;

        int count = 0;
        while (num > 0) {
            int left = (int)(num % 10);
            if (IsPeakOrValley(left, mid, right)) {
                count++;
            }

            right = mid;
            mid = left;
            num /= 10;
        }

        return count;
    }

    private static long TotalWavinessDirect(long num1, long num2) {
        long total = 0;
        for (long value = num1; value <= num2; value++) {
            total += GetWaviness(value);
        }
        return total;
    }

    private static long TotalWavinessInRange(long num1, long num2) {
        if (num2 < num1) {
            return 0;
        }

        string lowDigits = Math.Max(0, num1).ToString();
        string highDigits = num2.ToString();
        int length = highDigits.Length;
        lowDigits = lowDigits.PadLeft(length, '0');

        int stateSize = 2 * DigitStates * DigitStates;
        int memoSize = (length + 1) * stateSize;
        long[] waysMemo = new long[memoSize];
        long[] sumMemo = new long[memoSize];
        ulong[] seenBits = new ulong[(memoSize + 63) >> 6];

        int GetIndex(int pos, int startedIndex, int last1Index, int last2Index) {
            return ((pos * 2 + startedIndex) * DigitStates + last1Index) * DigitStates + last2Index;
        }

        bool IsSeen(int index) {
            int word = index >> 6;
            int bit = index & 63;
            return (seenBits[word] & (1UL << bit)) != 0;
        }

        void MarkSeen(int index) {
            int word = index >> 6;
            int bit = index & 63;
            seenBits[word] |= 1UL << bit;
        }

        (long ways, long wavinessSum) Dfs(int pos, bool lowTight, bool highTight, bool started, int last1, int last2) {
            if (pos == length) {
                return (1L, 0L);
            }

            int startedIndex = started ? 1 : 0;
            int last1Index = last1 + 1;
            int last2Index = last2 + 1;
            int memoIndex = GetIndex(pos, startedIndex, last1Index, last2Index);

            if (!lowTight && !highTight && IsSeen(memoIndex)) {
                return (waysMemo[memoIndex], sumMemo[memoIndex]);
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
                MarkSeen(memoIndex);
                waysMemo[memoIndex] = totalWays;
                sumMemo[memoIndex] = totalSum;
            }

            return (totalWays, totalSum);
        }

        return Dfs(0, true, true, false, -1, -1).wavinessSum;
    }

    public long TotalWaviness(long num1, long num2) {
        if (num2 < num1) {
            return 0;
        }

        long width = num2 - num1 + 1;
        if (width <= DirectScanThreshold) {
            return TotalWavinessDirect(num1, num2);
        }

        return TotalWavinessInRange(num1, num2);
    }
}