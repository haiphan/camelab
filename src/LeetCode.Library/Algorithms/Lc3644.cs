namespace LeetCode.Library.Algorithms;

public class Lc3644Solution {
    public int SortPermutation(int[] nums) {
        int n = nums.Length;
        int BIG = 0x1ffff;
        int km = BIG;
        for (int i = 0; i < n; i++) {
            int x = nums[i];
            if (i != x) {
                km &= x;
            }
        }
        if (km == BIG) {
            return 0;
        }
        return km;
    }
}