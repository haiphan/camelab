namespace LeetCode.Library.Algorithms;

public class Lc66Solution {
    public int[] PlusOne(int[] digits) {
        int c = 1;
        int N = digits.Length;
        for (int i = N - 1; i >= 0; i--) {
            if (c == 0) break;
            digits[i] += c;
            c = 0;
            if (digits[i] > 9) {
                c = 1;
                digits[i] %= 10;
            }
        }
        if (c > 0) {
            return [1, .. digits];
        }
        return digits;
    }
}