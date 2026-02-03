namespace LeetCode.Library.Algorithms;

public class Lc3637Solution {
    public bool IsTrionic(int[] nums) {
        int n = nums.Length;
        if (n < 4 || nums[1] <= nums[0]) return false;
        int p = 1;
        for (; p + 1 < n; p++) {
            if (nums[p + 1] <= nums[p]) break;
        }
        int q = p + 1;
        if (q + 2 > n || nums[q] >= nums[p]) return false;
        for (; q + 1 < n; q++) {
            if (nums[q + 1] >= nums[q]) break;
        }
        int u = q + 1;
        if (u >= n) return false;
        for (; u < n; u++) {
            if (nums[u] <= nums[u - 1]) return false;
        }
        return true;
    }
}