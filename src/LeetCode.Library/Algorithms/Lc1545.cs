namespace LeetCode.Library.Algorithms;

public class Lc1545Solution {
    public char FindKInL(int L, int k, int r) {
        if (L == 1) {
            return (char)('0' + r);
        }
        int half = L >> 1;
        if (k < half + 1) {
            return FindKInL(half, k, r);
        }
        if (k > half + 1) {
            return FindKInL(half, L - k + 1, 1 - r);
        }
        return (char)('0' + (1 - r));
    }
    public char FindKthBit(int n, int k) {
        return FindKInL((1 << n) - 1, k, 0);
    }
}