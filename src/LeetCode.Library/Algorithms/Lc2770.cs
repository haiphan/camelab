namespace LeetCode.Library.Algorithms;

public class Lc2770Solution {
    public int MaximumJumps(int[] nums, int target) {
        int n = nums.Length;
        if (n == 1) {
            return 0;
        }

        int[] dp = new int[n];
        Array.Fill(dp, -1);
        dp[0] = 0;

        long maxDiff = target;
        for (int i = 1; i < n; i++) {
            int current = nums[i];
            int best = -1;

            for (int j = i - 1; j >= 0; j--) {
                int prev = dp[j];
                if (prev == -1) {
                    continue;
                }

                long diff = (long)current - nums[j];
                if (diff < 0) {
                    diff = -diff;
                }

                if (diff <= maxDiff) {
                    int candidate = prev + 1;
                    if (candidate > best) {
                        best = candidate;

                        // Upper bound for any answer at index i.
                        if (best == i) {
                            break;
                        }
                    }
                }
            }

            dp[i] = best;
        }

        return dp[n - 1];
    }
}