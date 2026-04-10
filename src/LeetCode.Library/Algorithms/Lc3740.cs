namespace LeetCode.Library.Algorithms;

public class Lc3740Solution {
    public int MinimumDistance(int[] nums) {
        int n = nums.Length;
        int[] lastTwo = new int[n];
        int ans = int.MaxValue;
        for (int i = 0; i < n; i++) {
            int v = nums[i] - 1;
            int pos = i + 1;
            int x = lastTwo[v];
            int old = x & 0xFF, cur = (x >> 8);
            lastTwo[v] = (pos << 8) | cur;
            if (old > 0) {
                ans = Math.Min(ans, pos - old);
            }
        }
        return ans == int.MaxValue ? -1 : ans << 1;
    }
}