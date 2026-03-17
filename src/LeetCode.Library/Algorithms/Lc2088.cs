namespace LeetCode.Library.Algorithms;

public class Lc2088Solution {
    public int count(int[][] grid){
        int n = grid.Length, m = grid[0].Length, ans = 0;
        for(int i = 1; i < n; i++){
            for(int j = 1; j < m - 1; j++){
                if(grid[i][j] > 0 && grid[i - 1][j] > 0){ // check if current cell can be a tip of pyramid or not.
                    grid[i][j] = Math.Min(grid[i - 1][j - 1], grid[i - 1][j + 1]) + 1; // if its a pyramid, find the height.
                    ans += grid[i][j] - 1;
                }
            }
        }
        return ans;
    }
    public int CountPyramids(int[][] grid) {
        int ans = count(grid);

        // Restore binary values before running the second pass in the opposite direction.
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                grid[i][j] = grid[i][j] > 0 ? 1 : 0;
            }
        }

        Array.Reverse(grid);
        ans += count(grid);
        return ans;
    }
}