namespace LeetCode.Library.Algorithms;

public class Lc1674Solution {
    public int MinMoves(int[] nums, int limit) {
        int n = nums.Length;
        // delta[i] = number of moves needed to make all pairs sum to i
        int[] delta = new int[(limit << 1) + 2];

        for (int i = 0; i < n >> 1; i++) {
            int min = Math.Min(nums[i], nums[n - 1 - i]);
            int max = Math.Max(nums[i], nums[n - 1 - i]);

            delta[2] += 2;
            delta[min + 1]--;
            delta[min + max]--;
            delta[min + max + 1]++;
            delta[max + limit + 1]++;
        }

        int res = n, moves = 0;

        for (int targ = 2; targ <= limit * 2; targ++) {
            moves += delta[targ];
            res = Math.Min(res, moves);
        }

        return res;
    }
}