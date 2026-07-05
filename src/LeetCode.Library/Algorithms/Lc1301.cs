namespace LeetCode.Library.Algorithms;

public class Lc1301Solution {
    public int[] PathsWithMaxScore(IList<string> board) {
        const int MOD = 1_000_000_007;
        int n = board.Count;

        int width = n + 1;
        int[] nextScore = new int[width];
        int[] nextWays = new int[width];
        int[] currScore = new int[width];
        int[] currWays = new int[width];

        Array.Fill(nextScore, -1);

        for (int i = n - 1; i >= 0; --i) {
            Array.Fill(currScore, -1);
            Array.Fill(currWays, 0);
            bool rowReachable = false;

            for (int j = n - 1; j >= 0; --j) {
                char cell = board[i][j];

                if (cell == 'X') {
                    continue;
                }

                if (cell == 'S') {
                    currScore[j] = 0;
                    currWays[j] = 1;
                    rowReachable = true;
                    continue;
                }

                int up = nextScore[j];
                int right = currScore[j + 1];
                int diag = nextScore[j + 1];

                int best = up;
                if (right > best) {
                    best = right;
                }
                if (diag > best) {
                    best = diag;
                }

                if (best == -1) {
                    continue;
                }

                long ways = 0;

                if (up == best) {
                    ways += nextWays[j];
                }
                if (right == best) {
                    ways += currWays[j + 1];
                }
                if (diag == best) {
                    ways += nextWays[j + 1];
                }

                int value = (cell == 'E') ? 0 : cell - '0';

                currScore[j] = best + value;
                currWays[j] = (int)(ways % MOD);
                rowReachable = true;
            }

            if (!rowReachable) {
                return [0, 0];
            }

            (nextScore, currScore) = (currScore, nextScore);
            (nextWays, currWays) = (currWays, nextWays);
        }

        if (nextScore[0] == -1) {
            return [0, 0];
        }

        return [nextScore[0], nextWays[0]];
    }
}