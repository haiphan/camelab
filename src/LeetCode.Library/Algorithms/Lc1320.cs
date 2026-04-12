namespace LeetCode.Library.Algorithms;

public class Lc1320Solution {
    public int GetDist(int a, int b) {
        if (a == 26) return 0;
        return Math.Abs((a / 6) - (b / 6)) + Math.Abs((a % 6) - (b % 6));
    }
    public int MinimumDistance(string word) {
        int n = word.Length;
        if (n <= 1) return 0;

        int[] bestSavingWhenOtherFingerAt = new int[26];
        int totalSingleFingerCost = 0;
        int bestSaving = 0;

        for (int p = 0; p < n - 1; p++) {
            int from = word[p] - 'A';
            int to = word[p + 1] - 'A';
            int stepCost = GetDist(from, to);

            totalSingleFingerCost += stepCost;

            int bestForFrom = bestSavingWhenOtherFingerAt[from];
            for (int other = 0; other < 26; other++) {
                int candidate = bestSavingWhenOtherFingerAt[other] + stepCost - GetDist(other, to);
                if (candidate > bestForFrom) {
                    bestForFrom = candidate;
                }
            }

            bestSavingWhenOtherFingerAt[from] = bestForFrom;
            if (bestForFrom > bestSaving) {
                bestSaving = bestForFrom;
            }
        }

        return totalSingleFingerCost - bestSaving;
    }
}