namespace LeetCode.Library.Algorithms;

public class Lc2144Solution {
    public int MinimumCost(int[] cost) {
        int n = cost.Length;
        if (n == 2) {
            return cost[0] + cost[1];
        }
        Array.Sort(cost, (a,b) => a.CompareTo(b));
        int ans = 0;
        int i = n - 1;
        while (i >= 0) {
            ans += cost[i];
            if (i == 0) {
                break;
            }
            ans += cost[i - 1];
            i -= 3;
        }
        return ans;
    }
}