namespace LeetCode.Library.Algorithms;

public class Lc3345Solution {
    private int GetDigitProduct(int n) {
        if (n == 0) {
            return 0;
        }

        int product = 1;
        while (n > 0) {
            product *= n % 10;
            if (product == 0) {
                return 0;
            }
            n /= 10;
        }
        return product;
    }

    public int SmallestNumber(int n, int t) {
        int upperBound = n + ((10 - (n % 10)) % 10);
        for (int i = n; i <= upperBound; i++) {
            if (GetDigitProduct(i) % t == 0) {
                return i;
            }
        }

        // upperBound always ends with digit 0, so product is 0 and divisible by any t.
        return upperBound;
    }
}