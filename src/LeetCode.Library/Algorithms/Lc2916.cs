namespace LeetCode.Library.Algorithms;

public class Lc2916Solution {
    // Range-update/range-sum Fenwick tree over subarray-start positions.
    private sealed class FenwickRange {
        private readonly long[] _bit1;
        private readonly long[] _bit2;
        private readonly int _n;

        public FenwickRange(int n) {
            _n = n;
            _bit1 = new long[n + 2];
            _bit2 = new long[n + 2];
        }

        private static void Add(long[] bit, int n, int i, long v) {
            for (; i <= n; i += i & (-i)) bit[i] += v;
        }

        private static long Query(long[] bit, int i) {
            long sum = 0;
            for (; i > 0; i -= i & (-i)) sum += bit[i];
            return sum;
        }

        public void RangeAdd(int l, int r, long v) {
            if (l > r) return;
            Add(_bit1, _n, l, v);
            Add(_bit1, _n, r + 1, -v);
            Add(_bit2, _n, l, v * (l - 1));
            Add(_bit2, _n, r + 1, -v * r);
        }

        private long PrefixSum(int i) => Query(_bit1, i) * i - Query(_bit2, i);

        public long RangeSum(int l, int r) {
            if (l > r) return 0;
            return PrefixSum(r) - PrefixSum(l - 1);
        }
    }

    public int SumCounts(int[] nums) {
        int n = nums.Length;
        const int MOD = 1_000_000_007;

        // D(l) = distinct-count of subarray [l, r] for the current right endpoint r.
        var distinctCount = new FenwickRange(n);
        // Dictionary scales with distinct values present, unlike a fixed 1e5-sized array.
        var lastSeen = new Dictionary<int, int>(n);
        long curF = 0;
        long total = 0;

        for (int r = 1; r <= n; r++) {
            int val = nums[r - 1];
            int prev = lastSeen.GetValueOrDefault(val, 0);
            // Starts l in (prev, r-1] gain one new distinct element when nums[r] is appended.
            long sumBefore = distinctCount.RangeSum(prev + 1, r - 1);
            long countChanged = r - 1 - prev;
            curF = (curF + 2 * (sumBefore % MOD) + countChanged + 1) % MOD;
            total = (total + curF) % MOD;

            distinctCount.RangeAdd(prev + 1, r, 1);
            lastSeen[val] = r;
        }

        return (int)total;
    }
}