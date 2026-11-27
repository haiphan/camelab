namespace LeetCode.Library.Algorithms;

public class Lc3946Solution {
    public int MaximumSaleItems(int[][] items, int budget) {
        int[] factors = items.Select(item => item[0]).ToArray();
        int[] prices = items.Select(item => item[1]).ToArray();
        // max of factors
        int top = factors.Max();
        int[] have = new int[top + 1], gains = new int[top + 1];
        foreach (int factor in factors)
        {
            have[factor]++;
        }
        for (int factor = 1; factor <= top; factor++)
        {
            for (int multiple = factor; multiple <= top; multiple += factor)  // every factor-th cell is a multiple
            {
                gains[factor] += have[multiple];
            }
        }
        int cheapest = prices.Min();
        int[] best = new int[budget + 1];
        for (int b = 0; b <= budget; b++)
        {
            best[b] = b / cheapest;
        }
        foreach (int[] item in items) {
            int factor = item[0], price = item[1], gain = gains[factor];
            if (gain > price / cheapest)  // else the same money buys as many copies of the cheapest item
            {
                for (int money = budget; money >= price; money--)  // backwards: one first copy per item
                {
                    best[money] = Math.Max(best[money], best[money - price] + gain);
                }
            }
        }
        return best[budget];
    }
}