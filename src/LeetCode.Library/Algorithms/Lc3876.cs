namespace LeetCode.Library.Algorithms;

public class Lc3876Solution {
    public bool UniformArray(int[] nums1) {
        int n = nums1.Length;
        if (n == 1) return true;
        int minOdd = int.MaxValue;
        int minEven = int.MaxValue;
        foreach (var num in nums1) {
            if (num % 2 == 0) {
                minEven = Math.Min(minEven, num);
            } else {
                minOdd = Math.Min(minOdd, num);
            }
        }
        return minOdd < minEven || minOdd == int.MaxValue;
    }
}