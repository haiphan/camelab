namespace LeetCode.Library.Algorithms;

public class Lc3719Solution {
    public int LongestBalanced(int[] nums) {
        int n = nums.Length;
        int minv = nums[0];
        int maxv = nums[0];
        foreach(int x in nums) {
            minv = Math.Min(minv, x);
            maxv = Math.Max(maxv, x);
        }
        int[] seen = new int[maxv - minv + 1];
        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (n - i <= ans) break;
            
            int u = i + 1;
            int even = 0;
            int odd = 0;
            for (int j = i; j < n; j++) {
                int v = nums[j] - minv;
                if (seen[v] != u) {
                    seen[v] = u;
                    int par = nums[j] & 1;
                    odd += par;
                    even += 1 - par;
                }
                if (even == odd) {
                    ans = Math.Max(ans, j - i + 1);
                }
            }
        }
        return ans;
    }
}