namespace LeetCode.Library.Algorithms;
using System.Numerics;

public class Lc1680Solution {
    public int ConcatenatedBinary(int n) {
        uint ub = (uint)n;
        uint v = 0;
        long ans = 0;
        int MOD = 1000000007;
        while (v < ub) {
            v++;
            int l = 32 - BitOperations.LeadingZeroCount(v);
            ans = ((ans << l) | v) % MOD;
        }
        return (int)ans;
    }
}