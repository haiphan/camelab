namespace LeetCode.Library.Algorithms;

public class Lc3693Solution {
    public int ClimbStairs(int n, int[] costs) {
        if (n == 0) {
            return 0;
        }
        // a represents the minimum cost to reach the top from the current step with a 1-step jump
        // b represents the minimum cost to reach the top from the current step with a 2-step jump
        // c represents the minimum cost to reach the top from the current step with a 3-step jump
        int a = costs[n - 1];
        int b = int.MaxValue / 2;
        int c = int.MaxValue / 2;
        for (int i = n - 1; i >= 0; i--) {
            // virtual ground step (index 0) has no cost
            int cost = i == 0 ? 0 : costs[i - 1];
            (a, b, c) = (cost + Math.Min(a + 1, Math.Min(b + 4, c + 9)), a, b);
        }
        return a;
    }
}