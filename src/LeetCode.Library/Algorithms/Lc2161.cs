namespace LeetCode.Library.Algorithms;

public class Lc2161Solution {
    public int[] PivotArray(int[] nums, int pivot) {
        int n = nums.Length;
        int[] res = new int[n];
        int p = 0;
        int q = n - 1;

        for (int l = 0, r = n - 1; l < n; l++, r--) {
            int nl = nums[l];
            int nr = nums[r];

            if (nl < pivot) {
                res[p++] = nl;
            }

            if (nr > pivot) {
                res[q--] = nr;
            }
        }

        for (int i = p; i <= q; i++) {
                res[i] = pivot;
        }

        return res;
    }
}