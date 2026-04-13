namespace LeetCode.Library.Algorithms;

public class Lc1848Solution {
    public int GetMinDistance(int[] nums, int target, int start) {
        int n = nums.Length;
        if (nums[start] == target) return 0;
        for (int d = 1; start + d < n || start - d >= 0; d++) {
            if (start - d >= 0 && nums[start - d] == target) return d;
            if (start + d < n && nums[start + d] == target) return d;
        }
        return -1;
    }
}