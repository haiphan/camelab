namespace LeetCode.Library.Algorithms;

public class Lc3536Solution {
    public int MaxProduct(int n) {
        int big1 = -1;
        int big2 = -1;
        while (n > 0) {
            int digit = n % 10;
            if (digit > big1) {
                big2 = big1;
                big1 = digit;
            } else if (digit > big2) {
                big2 = digit;
            }
            n /= 10;
        }
        return big1 * big2;
    }
}