namespace LeetCode.Library.Algorithms;

public class Lc7Solution {
    public int Reverse(int x) {
        long y = 0;
        long n = x;
        int MAXV = 2147483647;
        int MINV = -2147483648;
        while (n != 0) {
            y = y * 10 + n % 10;
            if (y > MAXV || y < MINV) {
                return 0;
            }
            n /= 10;
        }
        return (int)y;
    }
}