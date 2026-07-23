namespace LeetCode.Library.Algorithms;

public class Lc3513Solution {
    public int UniqueXorTriplets(int[] nums) {
        int n = nums.Length;
        // count the number of bits needed to represent n
        int maxBit = (int)Math.Log2(n) + 1;
        return 1 << (maxBit - 3 / (n + 1));
    }
}