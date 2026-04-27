namespace LeetCode.Library.Algorithms;

public class Lc1391Solution {
    public bool HasValidPath(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        if (grid[0][0] == 5 || grid[m - 1][n - 1] == 4) {
            return false;
        }
        if (m == 1 && n == 1) {
            return true;
        }
        int[][] transitions = [
            [-1, 1, -1, 3],
            [0, -1, 2, -1],
            [3, 2, -1, -1],
            [1, -1, -1, 2],
            [-1, 0, 3, -1],
            [-1, -1, 1, 0]
        ];
        int[][] dirs = [[-1,0],[0,1],[1,0],[0,-1]];
        int[][] start = [[1, 3], [0, 2], [2, 3], [1, 2], [0, 3], [0, 1]];
        bool check(int d)
        {
            if (d == -1) {
                return false;
            }
            int r = dirs[d][0], c = dirs[d][1];
            bool[] visited = new bool[m * n];
            while (0 <= r && r < m && 0 <= c && c < n) {
                int idx = r * n + c;
                if (visited[idx]) {
                    return false;
                }
                visited[idx] = true;
                int t = transitions[grid[r][c] - 1][d];
                if (t == -1) {
                    return false;
                }
                if (r == m - 1 && c == n - 1) {
                    return true;
                }
                d = t;
                r += dirs[d][0];
                c += dirs[d][1];
            }
            return false;
        }
        int[] s = start[grid[0][0] - 1];
        return check(s[0]) || check(s[1]);
    }
}