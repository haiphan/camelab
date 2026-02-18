namespace LeetCode.Library.Algorithms;

public class Lc693Solution {
    public bool HasAlternatingBits(int n) {
        while (n > 0) {
            int cur = (n & 3);
            if (cur != 1 && cur != 2) return false;
            n >>= 1;
        }
        return true;
    }
}