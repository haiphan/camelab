namespace LeetCode.Library.Algorithms;

public class Lc3742Solution {
    public int MaxPathScore(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;
        int maxSpend = Math.Min(k, m + n - 2);

        int[][] prevRow = new int[n][];
        int[][] curRow = new int[n][];
        for (int j = 0; j < n; j++) {
            prevRow[j] = new int[maxSpend + 1];
            curRow[j] = new int[maxSpend + 1];
            Array.Fill(prevRow[j], -1);
        }

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                Array.Fill(curRow[j], -1);

                if (i == 0 && j == 0) {
                    curRow[j][0] = 0;
                    continue;
                }

                int cellValue = grid[i][j];
                int addCost = cellValue == 0 ? 0 : 1;
                int[] curCell = curRow[j];
                int[] topCell = i > 0 ? prevRow[j] : null!;
                int[] leftCell = j > 0 ? curRow[j - 1] : null!;

                if (addCost == 0) {
                    for (int t = 0; t <= maxSpend; t++) {
                        int bestPrev = -1;
                        if (i > 0) {
                            bestPrev = topCell[t];
                        }
                        if (j > 0 && leftCell[t] > bestPrev) {
                            bestPrev = leftCell[t];
                        }

                        if (bestPrev != -1) {
                            curCell[t] = bestPrev + cellValue;
                        }
                    }
                } else {
                    for (int t = 1; t <= maxSpend; t++) {
                        int idx = t - 1;
                        int bestPrev = -1;
                        if (i > 0) {
                            bestPrev = topCell[idx];
                        }
                        if (j > 0 && leftCell[idx] > bestPrev) {
                            bestPrev = leftCell[idx];
                        }

                        if (bestPrev != -1) {
                            curCell[t] = bestPrev + cellValue;
                        }
                    }
                }
            }
            (prevRow, curRow) = (curRow, prevRow);
        }

        int ans = -1;
        for (int t = 0; t <= maxSpend; t++) {
            if (prevRow[n - 1][t] > ans) {
                ans = prevRow[n - 1][t];
            }
        }
        return ans;
    }
}