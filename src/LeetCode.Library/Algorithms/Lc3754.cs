namespace LeetCode.Library.Algorithms;

public class Lc3754Solution {
    public long SumAndMultiply(int n) {
        if (n == 0) {
            return 0;
        }
        long sum = 0;
        long ans = 0;
        int tenPow = 1;
        while (n > 0) {
            int digit = n % 10;
            sum += digit;
            if (digit != 0) {
                ans = ans + digit * tenPow;
                tenPow *= 10;
            }
            n /= 10;
        }

        return ans * sum;
    }
}