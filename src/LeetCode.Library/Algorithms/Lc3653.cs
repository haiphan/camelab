namespace LeetCode.Library.Algorithms;

public class Lc3653Solution {
    private const int MOD = 1_000_000_007;

    private static long ModPow(long x, long p) {
        long result = 1;
        x %= MOD;
        while (p > 0) {
            if ((p & 1) != 0) {
                result = result * x % MOD;
            }

            x = x * x % MOD;
            p >>= 1;
        }

        return result;
    }

    private static long ModInverse(long x) {
        return ModPow(x, MOD - 2);
    }

    private static int ApplyNaive(int[] nums, int[][] queries) {
        int n = nums.Length;
        for (int i = 0; i < queries.Length; i++) {
            int[] q = queries[i];
            int l = q[0], r = q[1], k = q[2];
            long v = q[3] % MOD;
            if (k <= 0 || v == 1) {
                continue;
            }

            for (int j = l; j <= r; j += k) {
                nums[j] = (int)((long)nums[j] * v % MOD);
            }
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            ans ^= nums[i];
        }

        return ans;
    }

    public int XorAfterQueries(int[] nums, int[][] queries) {
        int n = nums.Length;
        if (n == 0) {
            return 0;
        }

        int m = queries.Length;
        int block = (int)Math.Sqrt(n) + 1;

        long naiveOps = 0;
        for (int i = 0; i < m; i++) {
            int[] q = queries[i];
            int l = q[0], r = q[1], k = q[2];
            if (k <= 0) {
                continue;
            }

            naiveOps += (r - l) / k + 1L;
        }

        long sqrtEstimate = (long)n * block + m;
        if (naiveOps <= sqrtEstimate) {
            return ApplyNaive(nums, queries);
        }

        long[][] delta = new long[block][];
        long[][] running = new long[block][];
        bool[] activeSmall = new bool[block];
        List<int> activeKList = [];

        for (int i = 0; i < m; i++) {
            int[] q = queries[i];
            int l = q[0], r = q[1], k = q[2];
            long v = q[3];

            if (k <= 0) {
                continue;
            }

            v %= MOD;
            if (v == 1) {
                continue;
            }

            if (k >= block || v == 0) {
                for (int j = l; j <= r; j += k) {
                    nums[j] = (int)((long)nums[j] * v % MOD);
                }
            } else {
                if (!activeSmall[k]) {
                    activeSmall[k] = true;
                    activeKList.Add(k);

                    delta[k] = new long[n];
                    Array.Fill(delta[k], 1L);
                    running[k] = new long[k];
                    Array.Fill(running[k], 1L);
                }

                delta[k][l] = delta[k][l] * v % MOD;

                int steps = (r - l) / k;
                int end = l + (steps + 1) * k;
                if (end < n) {
                    long inv = ModInverse(v);
                    delta[k][end] = delta[k][end] * inv % MOD;
                }
            }
        }

        int ans = 0;
        for (int i = 0; i < n; i++) {
            long cur = nums[i];
            for (int t = 0; t < activeKList.Count; t++) {
                int k = activeKList[t];
                int rem = i % k;
                running[k][rem] = running[k][rem] * delta[k][i] % MOD;
                cur = cur * running[k][rem] % MOD;
            }

            nums[i] = (int)cur;
            ans ^= nums[i];
        }

        return ans;
    }
}