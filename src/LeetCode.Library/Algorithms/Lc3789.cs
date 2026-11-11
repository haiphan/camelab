namespace LeetCode.Library.Algorithms;

public class Lc3789Solution {
    public long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2) {
        long minNeed = Math.Min(need1, need2);
        long maxNeed = Math.Max(need1, need2);

        // Total cost is convex in the number of combos bought, so the minimum is at one of these three breakpoints.
        long buyNoCombos = (long)need1 * cost1 + (long)need2 * cost2;
        long buyCombosForSmallerNeed = minNeed * costBoth + (need1 - minNeed) * cost1 + (need2 - minNeed) * cost2;
        long buyCombosForLargerNeed = maxNeed * costBoth;

        return Math.Min(buyNoCombos, Math.Min(buyCombosForSmallerNeed, buyCombosForLargerNeed));
    }
}