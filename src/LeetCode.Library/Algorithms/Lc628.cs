namespace LeetCode.Library.Algorithms;

public class Lc628Solution {
    public int MaximumProduct(int[] nums) {
        int n = nums.Length;
        if (n == 3) {
            return nums[0] * nums[1] * nums[2];
        }
        int BIG = 1001;
        int min1 = BIG, min2 = BIG;
        int max1 = -BIG, max2 = -BIG, max3 = -BIG;
        foreach (int num in nums) {
            if (num <= min1) {
                min2 = min1;
                min1 = num;
            } else if (num <= min2) {
                min2 = num;
            }
            if (num >= max1) {
                max3 = max2;
                max2 = max1;
                max1 = num;
            } else if (num >= max2) {
                max3 = max2;
                max2 = num;
            } else if (num >= max3) {
                max3 = num;
            }
        }
        return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
    }
}