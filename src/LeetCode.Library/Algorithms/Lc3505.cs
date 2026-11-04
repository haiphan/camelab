namespace LeetCode.Library.Algorithms;

public class Lc3505Solution {
    private int[] _bitCount = [];
    private long[] _bitSum = [];

    private void _BitAdd(int idx, int deltaCount, long deltaSum) {
        int n = _bitCount.Length;
        while (idx < n) {
            _bitCount[idx] += deltaCount;
            _bitSum[idx] += deltaSum;
            idx += idx & -idx;
        }
    }

    private (long count, long sum) _BitPrefix(int idx) {
        long count = 0, sum = 0;
        while (idx > 0) {
            count += _bitCount[idx];
            sum += _bitSum[idx];
            idx -= idx & -idx;
        }
        return (count, sum);
    }

    // Returns the smallest 1-based index i such that the prefix count >= k.
    private int _BitFindKth(long k) {
        int idx = 0;
        int bitMask = 1;
        while ((bitMask << 1) < _bitCount.Length) {
            bitMask <<= 1;
        }
        while (bitMask > 0) {
            int next = idx + bitMask;
            if (next < _bitCount.Length && _bitCount[next] < k) {
                k -= _bitCount[next];
                idx = next;
            }
            bitMask >>= 1;
        }
        return idx + 1;
    }

    public long MinOperations(int[] nums, int x, int k) {
        int n = nums.Length;

        int[] sorted = [.. nums];
        Array.Sort(sorted);
        int distinctCount = 0;
        for (int i = 0; i < n; i++) {
            if (distinctCount == 0 || sorted[i] != sorted[distinctCount - 1]) {
                sorted[distinctCount++] = sorted[i];
            }
        }

        _bitCount = new int[distinctCount + 1];
        _bitSum = new long[distinctCount + 1];

        int windowCount = n - x + 1;
        long[] cost = new long[windowCount];
        long windowSum = 0;
        int half = (x + 1) / 2;

        int[] compIdx = new int[n];
        for (int i = 0; i < n; i++) {
            compIdx[i] = Array.BinarySearch(sorted, 0, distinctCount, nums[i]) + 1;
        }

        for (int i = 0; i < n; i++) {
            _BitAdd(compIdx[i], 1, nums[i]);
            windowSum += nums[i];

            if (i >= x - 1) {
                int s = i - x + 1;
                int medianIdx = _BitFindKth(half);
                long median = sorted[medianIdx - 1];
                (long countLessEq, long sumLessEq) = _BitPrefix(medianIdx);
                // cost = (median * lowCount - lowSum) + (highSum - median * highCount)
                cost[s] = median * (2 * countLessEq - x) - 2 * sumLessEq + windowSum;

                _BitAdd(compIdx[s], -1, -nums[s]);
                windowSum -= nums[s];
            }
        }

        const long Inf = long.MaxValue / 2;
        long[] prev = new long[n + 1];
        long[] curr = new long[n + 1];

        for (int j = 1; j <= k; j++) {
            curr[0] = Inf;
            for (int i = 1; i <= n; i++) {
                curr[i] = curr[i - 1];
                if (i >= x) {
                    long cand = prev[i - x] + cost[i - x];
                    if (cand < curr[i]) {
                        curr[i] = cand;
                    }
                }
            }
            (prev, curr) = (curr, prev);
        }

        return prev[n];
    }
}