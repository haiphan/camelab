namespace LeetCode.Library.Algorithms;

public class Lc3789Solution {
    public long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2) {
        if (need1 == 0 && need2 == 0) {
            return 0;
        }
        long ans = long.MaxValue;
        long x = 0;
        ans = Math.Min(x * costBoth + (long)need1 * cost1 + (long)need2 * cost2, ans);
        x = Math.Min(need1, need2);
        ans = Math.Min(x * costBoth + (need1 - x) * cost1 + (need2 - x) * cost2, ans);
        x = Math.Max(need1, need2);
        ans = Math.Min(x * costBoth + Math.Max(need1 - x, 0) * cost1 + Math.Max(need2 - x, 0) * cost2, ans);
        return ans;
    }
}