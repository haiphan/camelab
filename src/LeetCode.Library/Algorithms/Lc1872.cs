namespace LeetCode.Library.Algorithms;

public class Lc1872Solution {
    public int StoneGameVIII(int[] stones) {
        int n = stones.Length;
        int prefixSum = stones[0];
        for (int i = 1; i < n; i++) {
            prefixSum += stones[i];
        }

        int maxScore = prefixSum;
        for (int i = n - 2; i >= 1; i--) {
            prefixSum -= stones[i + 1];
            maxScore = Math.Max(maxScore, prefixSum - maxScore);
        }

        return maxScore;
    }
}