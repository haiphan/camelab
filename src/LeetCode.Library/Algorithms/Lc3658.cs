namespace LeetCode.Library.Algorithms;

public class Lc3658Solution {
    private int GCD(int a, int b) {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
    public int GcdOfOddEvenSums(int n) {
        int sumOdd = n * n;
        int sumEven = n * (n + 1);
        return GCD(sumOdd, sumEven);
    }
}