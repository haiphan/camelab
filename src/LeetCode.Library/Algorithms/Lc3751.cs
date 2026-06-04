namespace LeetCode.Library.Algorithms;

public class Lc3751Solution {
    private const int MaxLimit = 100000;
    private static readonly int[] PrefixWaviness = new int[MaxLimit + 1];
    private static int _builtUpTo;

    private static int GetWaviness(int num) {
        if (num < 100) {
            return 0;
        }

        int right = num % 10;
        num /= 10;
        int mid = num % 10;
        num /= 10;

        int count = 0;
        while (num > 0) {
            int left = num % 10;
            if ((mid > left && mid > right) || (mid < left && mid < right)) {
                count++;
            }

            right = mid;
            mid = left;
            num /= 10;
        }

        return count;
    }

    private static void EnsurePrefixBuilt(int limit) {
        if (limit <= _builtUpTo) {
            return;
        }

        int target = Math.Min(limit, MaxLimit);
        for (int i = _builtUpTo + 1; i <= target; i++) {
            PrefixWaviness[i] = PrefixWaviness[i - 1] + GetWaviness(i);
        }
        _builtUpTo = target;
    }

    public int TotalWaviness(int num1, int num2) {
        EnsurePrefixBuilt(num2);
        return PrefixWaviness[num2] - PrefixWaviness[num1 - 1];
    }
}