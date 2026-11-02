namespace LeetCode.Library.Algorithms;

public class Lc462Solution {
    public int MinMoves2(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums);
        int l = 0;
        int r = n - 1;
        int moves = 0;
        while (l < r) {
            moves += nums[r] - nums[l];
            l++;
            r--;
        }
        return moves;
    }
}