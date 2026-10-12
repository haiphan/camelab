namespace LeetCode.Library.Algorithms;

public class Lc2897Solution {
    public int MaxSum(IList<int> nums, int k) {
        const long mod = 1000000007;
        int[] b = new int[30];

        // Step 1: count the 1-bits in every bit position
        foreach (int x in nums)
        {
            for (int i = 0; i < 30; i++)
            {
                if ((x & (1 << i)) != 0)
                {
                    b[i]++;
                }
            }

        }

        // Step 2: bit positions sorted by remaining-count, descending
        int[] order = new int[30];
        for (int i = 0; i < 30; i++) order[i] = i;
        Array.Sort(order, (x, y) => b[y] - b[x]);

        // Step 3: the j-th built number only changes once a bit position runs
        // out of 1s, so collapse the k numbers into <=30 equal-value buckets
        // instead of rebuilding every number bit by bit (avoids the O(30k) loop).
        long ans = 0, sum = 0;
        for (int t = 0; t < 30; t++)
        {
            int idx = order[t];
            if (b[idx] == 0) break;

            sum += 1L << idx;
            int hi = Math.Min(b[idx], k);
            int nextCount = t + 1 < 30 ? b[order[t + 1]] : 0;
            int lo = nextCount + 1;
            if (hi >= lo)
            {
                long count = hi - lo + 1;
                long sq = sum % mod * (sum % mod) % mod;
                ans = (ans + count * sq) % mod;
            }
        }

        return (int) ans;
    }
}