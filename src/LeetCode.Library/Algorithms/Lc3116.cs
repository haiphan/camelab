namespace LeetCode.Library.Algorithms;

public class Lc3116Solution {
    private static long CountLessEqual(long value, long[] plusLcm, int plusCount, long[] minusLcm, int minusCount) {
        long total = 0;
        for (int i = 0; i < plusCount; i++) {
            if (plusLcm[i] > value) {
                break;
            }
            total += value / plusLcm[i];
        }
        for (int i = 0; i < minusCount; i++) {
            if (minusLcm[i] > value) {
                break;
            }
            total -= value / minusLcm[i];
        }
        return total;
    }

    private static long Gcd(long a, long b) {
        while (b != 0) {
            (a, b) = (b, a % b);
        }
        return a;
    }

    private static long Lcm(long a, long b) => a / Gcd(a, b) * b;

    public long FindKthSmallest(int[] coins, int k) {
        int[] compressed = new int[coins.Length];
        int n = 0;
        foreach (int coin in coins) {
            bool redundant = false;
            for (int i = 0; i < coins.Length; i++) {
                if (coins[i] != coin && coin % coins[i] == 0) {
                    redundant = true;
                    break;
                }
            }
            if (!redundant) {
                compressed[n++] = coin;
            }
        }

        int subsetCount = 1 << n;

        // process largest coins first: their lcm grows fastest, so pruning below cuts more branches
        int[] sorted = new int[n];
        Array.Copy(compressed, sorted, n);
        Array.Sort(sorted, (a, b) => b - a);
        long hi = (long)k * sorted[n - 1];

        // skip subsets whose lcm already exceeds hi: their term is always 0, and any
        // superset's lcm only grows larger, so we can prune the whole branch upfront.
        // split by inclusion-exclusion sign so the hot binary-search loop needs no per-term multiply.
        long[] lcmFull = new long[subsetCount];
        bool[] pruned = new bool[subsetCount];
        int[] bitValue = new int[subsetCount];
        long[] plusLcm = new long[subsetCount];
        long[] minusLcm = new long[subsetCount];
        int plusCount = 0, minusCount = 0;
        for (int mask = 1; mask < subsetCount; mask++) {
            int lsb = mask & (-mask);
            int i = System.Numerics.BitOperations.TrailingZeroCount(lsb);
            int rest = mask ^ lsb;
            bitValue[mask] = bitValue[rest] + 1;
            if (rest != 0 && pruned[rest]) {
                pruned[mask] = true;
                continue;
            }
            long l = rest == 0 ? sorted[i] : Lcm(lcmFull[rest], sorted[i]);
            lcmFull[mask] = l;
            if (l > hi) {
                pruned[mask] = true;
                continue;
            }
            if ((bitValue[mask] & 1) == 1) {
                plusLcm[plusCount++] = l;
            } else {
                minusLcm[minusCount++] = l;
            }
        }
        Array.Sort(plusLcm, 0, plusCount);
        Array.Sort(minusLcm, 0, minusCount);

        long lo = sorted[n - 1];
        while (lo < hi) {
            long mid = lo + (hi - lo) / 2;
            if (CountLessEqual(mid, plusLcm, plusCount, minusLcm, minusCount) < k) {
                lo = mid + 1;
            } else {
                hi = mid;
            }
        }
        return lo;
    }
}