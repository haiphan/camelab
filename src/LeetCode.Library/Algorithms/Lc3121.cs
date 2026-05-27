using System.Numerics;

namespace LeetCode.Library.Algorithms;

public class Lc3121Solution {
    public int NumberOfSpecialChars(string word) {
        const int allLettersMask = (1 << 27) - 2;
        int upperMask = 0;
        int lowerMask = 0;

        foreach (char c in word) {
            int code = c & 31;
            int ci = (c >> 5) & 1;
            int bit = 1 << code;

            // If this letter is already dead (upper seen, lower cleared), it can no longer affect the result.
            if ((upperMask & bit) != 0 && (lowerMask & bit) == 0) {
                continue;
            }

            int upperSeen = (upperMask >> code) & 1;
            int value = 1 ^ (ci & upperSeen);

            // Uppercase (ci=0) sets upper bit; lowercase (ci=1) has no effect.
            upperMask |= bit * (ci ^ 1);

            // Lowercase writes computed value; uppercase has no effect.
            int lowerWriteMask = bit * ci;
            lowerMask = (lowerMask & ~lowerWriteMask) | ((value << code) * ci);

            if (upperMask == allLettersMask && lowerMask == 0) {
                return 0;
            }
        }

        int specialMask = upperMask & lowerMask;
        return BitOperations.PopCount((uint)specialMask);
    }
}