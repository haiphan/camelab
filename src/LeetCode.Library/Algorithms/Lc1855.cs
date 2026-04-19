namespace LeetCode.Library.Algorithms;

public class Lc1855Solution {
    public int MaxDistance(int[] nums1, int[] nums2) {
        int n = nums1.Length, m = nums2.Length;
        int i = 0, j = 0, ans = 0;
        while (i < n && j < m) {
            if (nums1[i] > nums2[j]) {
                i++;
            } else {
                ans = Math.Max(ans, j - i);
                j++;
            }
        }
        return ans;
    }
}