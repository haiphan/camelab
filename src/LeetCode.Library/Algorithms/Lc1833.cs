namespace LeetCode.Library.Algorithms;

public class Lc1833Solution {
    public int MaxIceCream(int[] costs, int coins) {
        int maxCost = 0;
        foreach (int c in costs)
        {
            if (c > maxCost) maxCost = c;
        }
        int[] buckets = new int[maxCost + 1];
        foreach (int c in costs)
        {
            buckets[c]++;
        }
        int ans = 0;
        for (int i = 1; i <= maxCost; ++i)
        {
            if (buckets[i] == 0) continue;
            int buy = Math.Min(buckets[i], coins / i);
            ans += buy;
            coins -= buy * i;
            if (coins < i) break;
        }
        return ans;
    }
}