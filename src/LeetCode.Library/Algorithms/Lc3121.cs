using System.Numerics;

namespace LeetCode.Library.Algorithms;

public class Lc3121Solution {
    public int NumberOfSpecialChars(string word) {
        int upperMask = 0;
        int lowerMask = 0;

        foreach (char c in word) {
            int code = c & 31;
            int ci = (c >> 5) & 1;
            int bit = 1 << code;
            int upperSeen = (upperMask >> code) & 1;
            int value = 1 ^ (ci & upperSeen);

            // Uppercase (ci=0) sets upper bit; lowercase (ci=1) has no effect.
            upperMask |= bit * (ci ^ 1);

            // Lowercase writes computed value; uppercase has no effect.
            int lowerWriteMask = bit * ci;
            lowerMask = (lowerMask & ~lowerWriteMask) | ((value << code) * ci);
        }

        int specialMask = upperMask & lowerMask;
        return BitOperations.PopCount((uint)specialMask);
    }
}