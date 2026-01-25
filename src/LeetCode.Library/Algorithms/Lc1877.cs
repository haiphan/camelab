namespace LeetCode.Library.Algorithms;

public class Lc1877Solution {
    public int MinPairSum(int[] nums) {
        const int MaxSize = 100001;
        int[] counts = new int[MaxSize];
        int l = MaxSize, r = 0;
        foreach (int x in nums) {
            l = Math.Min(l, x);
            r = Math.Max(r, x);
            counts[x]++;
        }
        int ans = 0;
        while (l <= r) {
            if (counts[l] == 0) {
                l++;
            } else if (counts[r] == 0) {
                r--;
            } else {
                ans = Math.Max(ans, l + r);
                counts[l]--;
                counts[r]--;
            }
        }
        return ans;
    }
}