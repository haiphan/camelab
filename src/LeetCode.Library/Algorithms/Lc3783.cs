namespace LeetCode.Library.Algorithms;

public class Lc3783Solution {
    public int MirrorDistance(int n) {
        int u = n;
        int m = 0;
        for (; n > 0; n /= 10) {
            m = m * 10 + (n % 10);
        }
        return Math.Abs(u - m);
    }
}