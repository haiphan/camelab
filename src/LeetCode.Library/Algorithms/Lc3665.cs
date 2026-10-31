namespace LeetCode.Library.Algorithms;

public class Lc3665Solution {
    public int UniquePaths(int[][] grid) {
        int MOD = 1_000_000_007;
        int m = grid.Length;
        int n = grid[0].Length;
        int[] down = new int[n];  // ways to enter each cell from above
        down[0] = 1;
        foreach (int[] row in grid) {
            int right = 0;  // ways to enter the current cell from the left
            for (int j = 0; j < n; j++) {
                if (row[j] == 1) {  // a mirror swaps the flows
                    (down[j], right) = (right, down[j]);
                }
                else {  // an empty cell merges them
                    right = down[j] = (right + down[j]) % MOD;
                }
            }
        }
        return down[n - 1];
    }
}