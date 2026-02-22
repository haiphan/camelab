namespace LeetCode.Library.Algorithms;
using System.Numerics;

public class Lc868Solution {
    public int BinaryGap(int n) {
        int maxd = 0;
        int prev = -1;
        while (n > 0) {
            int cur = n & -n;
            int p = 32 - BitOperations.LeadingZeroCount((uint)cur);
            if (prev != -1) {
                maxd = Math.Max(maxd, p - prev);
            }
            prev = p;
            n ^= cur;
        }
        return maxd;
    }
}