namespace LeetCode.Library.Algorithms;

public class Lc3550Solution {
    private int DigitSum(int n) {
        int sum = 0;
        while (n > 0) {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }
    public int SmallestIndex(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            if (DigitSum(nums[i]) == i) return i;
        }
        return -1;
    }
}