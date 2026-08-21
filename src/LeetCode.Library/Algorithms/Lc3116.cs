namespace LeetCode.Library.Algorithms;

public class Lc3116Solution {
    private static long CountLessEqual(long value, long[] lcm, int[] sign, int count) {
        long total = 0;
        for (int i = 0; i < count; i++) {
            total += sign[i] * (value / lcm[i]);
        }
        return total;
    }

    private static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);

    private static long Lcm(long a, long b) => a / Gcd(a, b) * b;

    public long FindKthSmallest(int[] coins, int k) {
        int n = coins.Length;
        int subsetCount = 1 << n;

        // process largest coins first: their lcm grows fastest, so pruning below cuts more branches
        int[] sorted = (int[])coins.Clone();
        Array.Sort(sorted, (a, b) => b - a);
        long hi = (long)k * sorted[n - 1];

        // skip subsets whose lcm already exceeds hi: their term is always 0, and any
        // superset's lcm only grows larger, so we can prune the whole branch upfront.
        long[] lcmFull = new long[subsetCount];
        bool[] pruned = new bool[subsetCount];
        long[] validLcm = new long[subsetCount];
        int[] validSign = new int[subsetCount];
        int validCount = 0;
        for (int mask = 1; mask < subsetCount; mask++) {
            int lsb = mask & (-mask);
            int i = System.Numerics.BitOperations.TrailingZeroCount(lsb);
            int rest = mask ^ lsb;
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
            validLcm[validCount] = l;
            validSign[validCount] = System.Numerics.BitOperations.PopCount((uint)mask) % 2 == 1 ? 1 : -1;
            validCount++;
        }

        long lo = 1;
        while (lo < hi) {
            long mid = lo + (hi - lo) / 2;
            if (CountLessEqual(mid, validLcm, validSign, validCount) < k) {
                lo = mid + 1;
            } else {
                hi = mid;
            }
        }
        return lo;
    }
}