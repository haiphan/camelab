namespace LeetCode.Library.Algorithms;
using System.Numerics;

public class Lc1009Solution {
    public int BitwiseComplement(int n) {
        if (n == 0) return 1;
        int L = 32 - BitOperations.LeadingZeroCount((uint)n);
        int mask = (1 << L) - 1;
        return n ^ mask;
    }
}