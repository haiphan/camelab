namespace LeetCode.Library.Algorithms;

public class Lc3689Solution {
    public long MaxTotalValue(int[] nums, int k) {
        int n = nums.Length;
        if (n == 1) {
            return 0;
        }
        int v = nums[0];
        int minv = v;
        int maxv = v;
        bool hasDiff = false;
        for (int i = 1; i < n; i++) {
            v = nums[i];
            if (v < minv) {
                minv = v;
                hasDiff = true;
            } else if (v > maxv) {
                maxv = v;
                hasDiff = true;
            }
        }
        if (!hasDiff) {
            return 0;
        }
        return (long)k * (maxv - minv);    
    }
}