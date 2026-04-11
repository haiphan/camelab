namespace LeetCode.Library.Algorithms;

public class Lc3741Solution {
    public int MinimumDistance(int[] nums) {
        int n = nums.Length;
        int[] older = new int[n];
        int[] recent = new int[n];
        int ans = int.MaxValue;
        for (int i = 0; i < n; i++) {
            int v = nums[i] - 1;
            int pos = i + 1;
            int old = older[v];
            int cur = recent[v];
            older[v] = cur;
            recent[v] = pos;
            if (old > 0) {
                ans = Math.Min(ans, pos - old);
            }
        }
        return ans == int.MaxValue ? -1 : ans << 1;
    }
}