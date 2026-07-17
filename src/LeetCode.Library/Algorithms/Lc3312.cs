namespace LeetCode.Library.Algorithms;

public class Lc3312Solution {
    static int UpperBound(long[] arr, int length, long target)
    {
        int left = 0, right = length;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] <= target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        return left;
    }

    public int[] GcdValues(int[] nums, long[] queries) {
        if (nums.Length < 2)
        {
            return new int[queries.Length];
        }

        int M = 0;
        foreach (int x in nums)
        {
            M = Math.Max(M, x);
        }

        long[] valueCount = new long[M + 1];
        foreach (int x in nums)
        {
            valueCount[x]++;
        }

        long[] divisibleCount = new long[M + 1];
        for (int d = 1; d <= M; d++)
        {
            for (int multiple = d; multiple <= M; multiple += d)
            {
                divisibleCount[d] += valueCount[multiple];
            }
        }

        long[] exactGcdPairs = new long[M + 1];
        for (int d = M; d >= 1; d--)
        {
            long cnt = divisibleCount[d];
            exactGcdPairs[d] = (cnt * (cnt - 1)) >> 1;
            for (int multiple = d + d; multiple <= M; multiple += d)
            {
                exactGcdPairs[d] -= exactGcdPairs[multiple];
            }
        }

        long[] prefix = new long[M + 1];
        for (int g = 1; g <= M; g++)
        {
            prefix[g] = prefix[g - 1] + exactGcdPairs[g];
        }

        int m = queries.Length;
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            ans[i] = UpperBound(prefix, M + 1, queries[i]);
        }

        return ans;
    }
}