namespace LeetCode.Library.Algorithms;

public class Lc2091Solution {
    public int MinimumDeletions(int[] nums) {
        int n = nums.Length;
        if (n <= 1) return 1;
        int minVal = int.MaxValue;
        int maxVal = int.MinValue;
        int minIndex = -1;
        int maxIndex = -1;
        for (int i = 0; i < n; i++) {
            if (nums[i] < minVal) {
                minVal = nums[i];
                minIndex = i;
            }
            if (nums[i] > maxVal) {
                maxVal = nums[i];
                maxIndex = i;
            }
        }
        int left = Math.Min(minIndex, maxIndex);
        int right = Math.Max(minIndex, maxIndex);
        return Math.Min(Math.Min(right + 1, n - left), left + 1 + n - right);
    }
}