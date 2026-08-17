namespace LeetCode.Library.Algorithms;

public class Lc1563Solution {
    public int StoneGameV(int[] stoneValue) {
        int n = stoneValue.Length;
        if (n <= 1) {
            return 0;
        }
        if (n == 2) {
            return Math.Min(stoneValue[0], stoneValue[1]);
        }

        int[] prefixSum = new int[n + 1];
        for (int i = 0; i < n; i++) {
            prefixSum[i + 1] = prefixSum[i] + stoneValue[i];
        }

        int[,] dp = new int[n, n];
        int[,] rightBest = new int[n, n];
        for (int i = 0; i < n; i++) {
            rightBest[i, i] = -prefixSum[i];
        }

        for (int left = n - 2; left >= 0; left--) {
            int mid = left;
            int processedMid = left - 1;
            int leftBest = int.MinValue;
            for (int right = left + 1; right < n; right++) {
                while (mid < right - 1
                    && prefixSum[mid + 1] - prefixSum[left] < prefixSum[right + 1] - prefixSum[mid + 1]) {
                    mid++;
                }

                int leftSum = prefixSum[mid + 1] - prefixSum[left];
                int rightSum = prefixSum[right + 1] - prefixSum[mid + 1];

                int lastLeftMid = leftSum <= rightSum ? mid : mid - 1;
                while (processedMid < lastLeftMid) {
                    processedMid++;
                    leftBest = Math.Max(leftBest, dp[left, processedMid] + prefixSum[processedMid + 1]);
                }

                int best = leftBest == int.MinValue ? 0 : leftBest - prefixSum[left];
                int firstRightMid = leftSum >= rightSum ? mid : mid + 1;
                if (firstRightMid < right) {
                    best = Math.Max(best, rightBest[firstRightMid + 1, right] + prefixSum[right + 1]);
                }

                dp[left, right] = best;
                rightBest[left, right] = dp[left, right] - prefixSum[left];
                if (left + 1 <= right) {
                    rightBest[left, right] = Math.Max(rightBest[left, right], rightBest[left + 1, right]);
                }
            }
        }

        return dp[0, n - 1];
    }
}