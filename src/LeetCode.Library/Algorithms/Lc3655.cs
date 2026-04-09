namespace LeetCode.Library.Algorithms;

public class Lc3655Solution {
    private const int MOD = 1_000_000_007;
    private int ModPow(long a, long b) {
        long ans = 1;
        a %= MOD;
        while (b > 0) {
            if ((b & 1) == 1) {
                ans = ans * a % MOD;
            }
            a = a * a % MOD;
            b >>= 1;
        }
        return (int)ans;
    }
    private int ModInverse(int a) {
        return ModPow(a, MOD - 2);
    }
    public int XorAfterQueries(int[] nums, int[][] queries) {
        int n = nums.Length;
        int m = queries.Length;
        int block = (int)Math.Sqrt(n);
        List<List<int[]>> groups = new List<List<int[]>>(block);
        for (int i = 0; i < block; i++) {
            groups.Add(new List<int[]>());
        }
        foreach (int[] q in queries) {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            if (k < block)
            {
                groups[k].Add([l, r, v]);
            } else {
                for (int i = l; i <= r; i += k) {
                    nums[i] = (int)((long)nums[i] * v % MOD);
                }
            }
        }
        long[] diff = new long[n + block];
        for (int k = 1; k < block; k++)
        {
            if (groups[k].Count == 0) {
                continue;
            }
            Array.Fill(diff, 1);
            foreach (int[] q in groups[k])
            {
                int l = q[0], r = q[1], v = q[2];
                diff[l] = diff[l] * v % MOD;
                int end = ((r - l) / k + 1) * k + l;
                diff[end] = diff[end] * ModInverse(v) % MOD;
            }
            for (int i = k; i < n; i++) {
                diff[i] = diff[i] * diff[i - k] % MOD;
            }
            for (int i = 0; i < n; i++) {
                nums[i] = (int)((long)nums[i] * diff[i] % MOD);
            }
        }
        int ans = 0;
        foreach (int num in nums) {
            ans ^= num;
        }
        return ans;
    }
}