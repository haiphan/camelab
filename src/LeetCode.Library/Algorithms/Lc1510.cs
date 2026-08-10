namespace LeetCode.Library.Algorithms;

public class Lc1510Solution {
    private const int MaxN = 100_000;
    private static readonly bool[] Dp = BuildCache();

    public bool WinnerSquareGame(int n) {
        return Dp[n];
    }

    private static bool[] BuildCache() {
        bool[] dp = new bool[MaxN + 1];
        for (int i = 1; i <= MaxN; i++) {
            bool win = false;
            // Generate 1, 4, 9, ... using odd differences: nextSquare = square + 3, +5, +7, ...
            for (int square = 1, delta = 3; square <= i; square += delta, delta += 2) {
                if (!dp[i - square]) {
                    win = true;
                    break;
                }
            }

            dp[i] = win;
        }

        return dp;
    }
}