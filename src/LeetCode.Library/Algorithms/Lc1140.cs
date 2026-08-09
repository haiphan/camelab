namespace LeetCode.Library.Algorithms;

public class Lc1140Solution {
    private static int STEP = 1 << 20;
    private static int MASK = STEP - 1;
    // dp[i, m] = gen | win, where win is the maximum stones the current player can get
    private static int[,] dp = new int[101, 101];
    private static int[] sufSum = new int[101];
    private static int gen = 0;
    // solve the game recursively, return the maximum stones the current player can get
    // i: the current index of piles
    // m: the current M value
    // n: the total number of piles
    private int solveRecursive(int i, int m, int n)
    {
        if (i >= n) {
            return 0;
        }
        if (2 * m >= n - i) {
            return sufSum[i];
        }
        if (dp[i, m] >= gen)
        {
            return dp[i, m] & MASK;
        }
        int win = 0;
        for (int j = 1; j <= 2 * m; j++)
        {
            win = Math.Max(win, sufSum[i] - solveRecursive(i + j, Math.Max(m, j), n));
        }
        dp[i, m] = gen | win;
        return win;
    }
    public int StoneGameII(int[] piles) {
        int n = piles.Length;
        gen += STEP;
        sufSum[n] = 0;
        for (int i = n - 1; i >= 0; i--) {
            sufSum[i] = sufSum[i + 1] + piles[i];
        }
        return solveRecursive(0, 1, n);
    }
}