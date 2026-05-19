namespace LeetCode.Library.Algorithms;

public class Lc2540Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;
        int i = 0, j = 0;
        while (i < m && j < n) {
            int a = nums1[i], b = nums2[j];
            if (a < b) {
                i++;
            } else if (a > b) {
                j++;
            } else /* a == b */ {
                return a;
            }
        }
        return -1;
    }
}