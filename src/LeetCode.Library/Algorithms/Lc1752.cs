namespace LeetCode.Library.Algorithms;

public class Lc1752Solution {
    public bool Check(int[] nums) {
        int n = nums.Length;
        if (n == 1) {
            return true;
        }
        bool rotated = false;
        for (int i = 0; i < n; i++) {
            if (nums[i] > nums[(i + 1) % n]) {
                if (rotated) {
                    return false;
                }
                rotated = true;
            }
        }
        return true;
    }
}