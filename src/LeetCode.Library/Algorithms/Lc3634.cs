namespace LeetCode.Library.Algorithms;

public class Lc3634Solution {
    public int MinRemoval(int[] nums, int k) {
        int n = nums.Length;
        if (n == 1) return 0;
        Array.Sort(nums);
        int l = 0;
        int maxl = 0;
        for (int r = 0; r < n; r++) {
            if (n - l <= maxl) break;
            if (r - l + 1 <= maxl) continue;
            while ((long)nums[l] * k < nums[r]) l++;
            maxl = Math.Max(maxl, r - l + 1);
        }
        return n - maxl;
    }
}