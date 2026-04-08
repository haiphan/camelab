namespace LeetCode.Library.Algorithms;

public class Lc3653Solution {
    private int MOD = 1000000007;
    public int XorAfterQueries(int[] nums, int[][] queries) {
        int n = nums.Length, m = queries.Length;
        for (int i = 0; i < m; i++) {
            int[] q = queries[i];
            int l = q[0], r = q[1], k = q[2];
            long v = q[3];
            for (int j = l; j <= r; j += k) {
                long x = nums[j] * v % MOD;
                nums[j] = (int)x;
            }
        }
        int ans = 0;
        for (int i = 0; i < n; i++) {
            ans ^= nums[i];
        }
        return ans;
    }
}