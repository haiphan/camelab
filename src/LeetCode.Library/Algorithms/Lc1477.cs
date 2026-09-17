namespace LeetCode.Library.Algorithms;

public class Lc1477Solution {
    public int MinSumOfLengths(int[] arr, int target) {
        int n = arr.Length;
        int[] left = new int[n]; // 0 means "no valid subarray found yet" (lengths are always >= 1)
        int sum = 0, best = int.MaxValue;
        for (int i = 0, j = 0; i < n; i++) {
            sum += arr[i];
            while (sum > target) sum -= arr[j++];
            if (sum == target) {
                left[i] = i - j + 1;
                if (j > 0 && left[j - 1] != 0) best = Math.Min(best, left[j - 1] + left[i]);
                if (best == 2) break; // 2 is the theoretical minimum (two length-1 subarrays)
            }
            if (i > 0) {
                if (left[i] == 0) left[i] = left[i - 1];
                else if (left[i - 1] != 0) left[i] = Math.Min(left[i], left[i - 1]);
            }
        }
        return best == int.MaxValue ? -1 : best;
    }
}