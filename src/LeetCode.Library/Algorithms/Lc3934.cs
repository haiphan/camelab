namespace LeetCode.Library.Algorithms;

public class Lc3934Solution {
    public int SmallestUniqueSubarray(int[] nums) {
        int n = nums.Length;
        if (n == 1) {
            return 1;
        }

        int[] sa = BuildSuffixArray(nums);
        int[] rankOfIndex = new int[n];
        for (int i = 0; i < n; i++) {
            rankOfIndex[sa[i]] = i;
        }

        int[] lcp = BuildLcp(nums, sa, rankOfIndex);

        // For each start position p, maxMatch is the longest a subarray starting at p
        // can agree with any other subarray. Any length beyond that is unique to p.
        int answer = n;
        for (int p = 0; p < n; p++) {
            int r = rankOfIndex[p];
            int left = r > 0 ? lcp[r] : 0;
            int right = r < n - 1 ? lcp[r + 1] : 0;
            int maxMatch = Math.Max(left, right);
            int remaining = n - p;
            if (maxMatch < remaining) {
                answer = Math.Min(answer, maxMatch + 1);
            }
        }

        return answer;
    }

    // Prefix-doubling suffix array construction using two stable counting-sort passes
    // (LSD radix sort) per round instead of a comparison-based sort. This runs in
    // O(n log n) with a small constant, avoiding delegate-call overhead entirely.
    private static int[] BuildSuffixArray(int[] s) {
        int n = s.Length;
        int[] sa = new int[n];
        int[] rank = new int[n];
        int[] tmp = new int[n];
        int[] sortedBySecondKey = new int[n];
        // maxRank is always < n after compression/renumbering, so a single buffer of
        // size n + 3 covers every round's bucket range and is reused instead of being
        // reallocated (and re-zeroed) on every doubling step.
        int[] count = new int[n + 3];

        int maxRank = CompressInitialRanks(s, rank);

        if (maxRank == n - 1) {
            // All initial ranks are already distinct; rank is a permutation of 0..n-1.
            for (int i = 0; i < n; i++) {
                sa[rank[i]] = i;
            }

            return sa;
        }

        for (int k = 1; maxRank < n - 1 && k < n; k <<= 1) {
            // Pass 1: stable counting sort by the second key (rank[i + k], or -1 if out of bounds).
            CountingSortBySecondKey(rank, k, n, maxRank, count, sortedBySecondKey);

            // Pass 2: stable counting sort by the first key (rank[i]).
            CountingSortByFirstKey(rank, n, maxRank, count, sortedBySecondKey, sa);

            tmp[sa[0]] = 0;
            for (int i = 1; i < n; i++) {
                bool sameFirst = rank[sa[i - 1]] == rank[sa[i]];
                bool sameSecond = SecondKey(rank, sa[i - 1], k, n) == SecondKey(rank, sa[i], k, n);
                tmp[sa[i]] = tmp[sa[i - 1]] + (sameFirst && sameSecond ? 0 : 1);
            }

            Array.Copy(tmp, rank, n);
            maxRank = rank[sa[n - 1]];
        }

        return sa;
    }

    // Values are bounded (1 <= nums[i] <= 1e5), so ranks can be compressed with an
    // O(n + maxVal) counting pass instead of an O(n log n) sort + binary search.
    private static int CompressInitialRanks(int[] s, int[] rank) {
        int n = s.Length;
        int maxVal = 0;
        for (int i = 0; i < n; i++) {
            if (s[i] > maxVal) {
                maxVal = s[i];
            }
        }

        bool[] present = new bool[maxVal + 1];
        for (int i = 0; i < n; i++) {
            present[s[i]] = true;
        }

        int[] denseIndex = new int[maxVal + 1];
        int distinct = 0;
        for (int v = 0; v <= maxVal; v++) {
            if (present[v]) {
                denseIndex[v] = distinct++;
            }
        }

        for (int i = 0; i < n; i++) {
            rank[i] = denseIndex[s[i]];
        }

        return distinct - 1;
    }

    private static int SecondKey(int[] rank, int i, int k, int n) => i + k < n ? rank[i + k] : -1;

    private static void CountingSortBySecondKey(int[] rank, int k, int n, int maxRank, int[] count, int[] result) {
        // Shift keys by 1 so that the "-1" sentinel maps to bucket 0.
        int length = maxRank + 3;
        Array.Clear(count, 0, length);
        for (int i = 0; i < n; i++) {
            count[SecondKey(rank, i, k, n) + 2]++;
        }

        for (int i = 1; i < length; i++) {
            count[i] += count[i - 1];
        }

        for (int i = 0; i < n; i++) {
            result[count[SecondKey(rank, i, k, n) + 1]++] = i;
        }
    }

    private static void CountingSortByFirstKey(int[] rank, int n, int maxRank, int[] count, int[] input, int[] result) {
        int length = maxRank + 2;
        Array.Clear(count, 0, length);
        for (int i = 0; i < n; i++) {
            count[rank[i] + 1]++;
        }

        for (int i = 1; i < length; i++) {
            count[i] += count[i - 1];
        }

        for (int i = 0; i < n; i++) {
            int p = input[i];
            result[count[rank[p]]++] = p;
        }
    }

    private static int[] BuildLcp(int[] s, int[] sa, int[] rankOfIndex) {
        int n = s.Length;
        int[] lcp = new int[n];
        int h = 0;

        for (int i = 0; i < n; i++) {
            int r = rankOfIndex[i];
            if (r > 0) {
                int j = sa[r - 1];
                while (i + h < n && j + h < n && s[i + h] == s[j + h]) {
                    h++;
                }

                lcp[r] = h;
                if (h > 0) {
                    h--;
                }
            } else {
                h = 0;
            }
        }

        return lcp;
    }
}
