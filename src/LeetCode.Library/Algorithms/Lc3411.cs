namespace LeetCode.Library.Algorithms;

public class Lc3411Solution {
    private int gcd(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public int MaxLength(int[] nums) {
        int best = 2, left = 0, product = 1;
        for (int right = 0; right < nums.Length; right++) {
            int x = nums[right];
            while (gcd(product, x) > 1)
            {
                product /= nums[left++];
            }

            product *= x;
            best = Math.Max(best, right - left + 1);
        }
        return best;
    }
}