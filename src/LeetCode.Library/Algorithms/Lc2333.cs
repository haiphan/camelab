namespace LeetCode.Library.Algorithms;

public class Lc2333Solution {
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        int n = nums1.Length;
        long k = 1L * k1 + k2;
        int M = 0;
        int[] diff = new int[n];

        for (int i = 0; i < n; i++)
        {
            diff[i] = Math.Abs(nums1[i] - nums2[i]);
            M = Math.Max(M, diff[i]);
        }
            

        int[] bucket = new int[M + 1];
        foreach (int x in diff)
        {
            bucket[x]++;
        }

        for (int i = M; i > 0 && k > 0; i--) {
            int take = (int)Math.Min((long)bucket[i], k);
            bucket[i] -= take;
            bucket[i - 1] += take;
            k -= take;
        }

        long ans = 0;
        for (int i = 1; i <= M; i++)
        {
            ans += 1L * bucket[i] * i * i;
        }

        return ans;
    }
}