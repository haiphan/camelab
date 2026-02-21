namespace LeetCode.Library.Algorithms;
using System.Numerics;

public class Lc762Solution {
        public int[][] nck = [];
    public int[] PL = [2, 3, 5, 7, 11, 13, 17, 19, 23];
    public void PrecomputeCombinations(int n) {
        // Initialize a jagged array (array of arrays)
        nck = new int[n + 1][];

        for (int i = 0; i <= n; i++) {
            nck[i] = new int[i + 1]; // Each row only needs to be as long as its index
            nck[i][0] = 1;           // nC0 is always 1
            nck[i][i] = 1;           // nCn is always 1

            for (int j = 1; j < i; j++)
            {
                // Pascal's Identity: nCk = (n-1)C(k-1) + (n-1)Ck
                nck[i][j] = nck[i - 1][j - 1] + nck[i - 1][j];
            }
        }
    }
    public int CountZeroToU(int U, int k) {
        int total = 0;
        int onesSoFar = 0;
        int bitLen = 32 - BitOperations.LeadingZeroCount((uint)U);
        if (bitLen < k) {
            return 0;
        }
        // Iterate through bits from MSB to LSB
        for (int i = bitLen - 1; i >= 0; i--) {
            if (((U >> i) & 1) == 1) {
                // If we treat this bit as '0' instead of '1', 
                // the resulting number is guaranteed to be < U.
                // We choose the remaining needed '1's from the 'i' bits below.
                int needed = k - onesSoFar;
                if (needed < 0) break;
                if (needed <= i) {
                    total += nck[i][needed];
                }
                onesSoFar++;
            }
        }

        // Check if U itself has exactly k ones
        if (onesSoFar == k) {
            total++;
        }
        return total;
    }
    public int CountPrimeSetBits(int left, int right) {
        int bitLen = 32 - BitOperations.LeadingZeroCount((uint)right);
        PrecomputeCombinations(bitLen);
        int ans = 0;
        foreach (int p in PL) {
            if (p > bitLen) break;
            ans += CountZeroToU(right, p) - CountZeroToU(left-1, p);
        }
        return ans;
    }
}