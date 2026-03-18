namespace LeetCode.Library.Algorithms;

public class Lc3070Solution {
    public int CountSubmatrices(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;
        int cnt = 0;
        int cMax = n;
        if (grid[0][0]>k) return 0;// early stop
        cnt++;
        for(int j = 1; j < n; j++){
            grid[0][j] += grid[0][j-1];// add previous term to x
            if(grid[0][j] > k) {
                cMax = j;
                break;
            }
            cnt++;
        }

        for(int i = 1; i < m; i++){
            grid[i][0]+=grid[i-1][0];
            if (grid[i][0]>k) break;// check the prefix sum grid[i][0]
            cnt++;
            for(int j = 1; j < cMax; j++){
                grid[i][j] += grid[i-1][j]+grid[i][j-1]-grid[i-1][j-1];
                if (grid[i][j] > k){// no need for computing for the rest cols
                    cMax = j;
                    break;
                }
                cnt++;// add 1 to cnt
            }
        }
        return cnt;
    }
}