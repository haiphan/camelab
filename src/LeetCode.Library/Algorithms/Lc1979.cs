namespace LeetCode.Library.Algorithms;

public class Lc1979Solution {
    private int GCD(int a, int b) {
        while (b != 0) {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
    public int FindGCD(int[] nums) {
        int minv = int.MaxValue;
        int maxv = int.MinValue;
        foreach (int x in nums) {
            minv = Math.Min(minv, x);
            maxv = Math.Max(maxv, x);
        }
        return GCD(minv, maxv);
    }
}