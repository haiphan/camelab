namespace LeetCode.Library.Algorithms;

public class Lc3619Solution {
    public int CountIslands(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[] stack = new int[m * n]; // encoded as r * n + c; island can push at most m*n cells
        int[] dr = [-1, 1, 0, 0];
        int[] dc = [0, 0, -1, 1];
        int ans = 0;
        for (int i = 0; i < m; i++) {
            int[] row = grid[i];
            for (int j = 0; j < n; j++) {
                if (row[j] <= 0)
                {
                    continue;
                }

                long total = row[j];
                row[j] = -1; // mark as visited
                int top = 0;
                stack[top++] = i * n + j;
                while (top > 0)
                {
                    int cur = stack[--top];
                    int r = cur / n;
                    int c = cur % n;
                    for (int d = 0; d < 4; d++)
                    {
                        int nr = r + dr[d];
                        int nc = c + dc[d];
                        if (nr < 0 || nr >= m)
                        {
                            continue;
                        }

                        int[] nRow = grid[nr];
                        if (nc < 0 || nc >= n || nRow[nc] <= 0)
                        {
                            continue;
                        }

                        total += nRow[nc];
                        nRow[nc] = -1; // mark as visited
                        stack[top++] = nr * n + nc;
                    }
                }

                if (total % k == 0)
                {
                    ans++;
                }
            }
        }
        return ans;
    }
}