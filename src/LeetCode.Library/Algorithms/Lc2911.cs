namespace LeetCode.Library.Algorithms;

public class Lc2911Solution {
    private int peel(String s, int i, int j, int d) {  // s[i:j] in blocks of d: the outer pair of blocks, then the inside
        int changes = 0;
        for (; j - i > d; i += d, j -= d)
        {
            for (int t = 0; t < d; t++)
            {
                if (s[i + t] != s[j - d + t])
                {
                    changes++;
                }
            }
        }
        return changes;
    }

    private int extend(int[] best, int[][] cost, int j) {  // the newest piece s[i:j] starts at an old cut i and gets at least 2 letters
        return Enumerable.Range(0, j - 1).Select(i => best[i] + cost[i][j]).Min();
    }
    public int MinimumChanges(string s, int k) {
        int n = s.Length, inf = int.MaxValue / 2;
        int[][] cost = new int[n + 1][];  // cost[i][j]: changes to make s[i:j] a semi-palindrome
        for (int i = 0; i <= n; i++)
        {
            cost[i] = new int[n + 1];
            for (int j = 0; j <= n; j++)
            {
                cost[i][j] = inf;
            }
        }
        for (int d = 1; 2 * d <= n; d++)
        {
            for (int length = 2 * d; length <= n; length += d)  // every length that d divides, with d < length
            {
                for (int i = 0, j = length; j <= n; i++, j++)
                {
                    cost[i][j] = Math.Min(cost[i][j], peel(s, i, j, d));
                }
            }
        }
        int[] best = new int[n + 1];  // best[j]: the fewest changes for s[:j] cut into the pieces placed so far
        Array.Fill(best, inf);
        best[0] = 0;
        for (int pieces = 1; pieces < k; pieces++) {  // every piece but the last
            int[] next = new int[n + 1];
            Array.Fill(next, inf);
            for (int j = 2 * pieces; j <= n - 2 * (k - pieces); j++)  // 2 letters for each piece, placed or still to come
            {
                next[j] = extend(best, cost, j);
            }
            best = next;
        }
        return extend(best, cost, n);  // the last piece ends at n
    }
}