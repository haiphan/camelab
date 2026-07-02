namespace LeetCode.Library.Algorithms;

public class Lc3286Solution {
    public bool FindSafeWalk(IList<IList<int>> grid, int health) {
        int rows = grid.Count;
        int cols = grid[0].Count;
        int firstVal = grid[0][0];
        int lastVal = grid[rows - 1][cols - 1];

        if (rows == 1 && cols == 1) {
            return health > firstVal;
        }

        // Any valid path must include both start and destination cells.
        if (health <= firstVal + lastVal) {
            return false;
        }

        // 0-1 BFS on path damage because each cell cost is either 0 or 1.
        int[,] minDamage = new int[rows, cols];
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                minDamage[r, c] = int.MaxValue;
            }
        }

        int[] dr = [1, -1, 0, 0];
        int[] dc = [0, 0, 1, -1];

        LinkedList<(int r, int c)> deque = new();
        minDamage[0, 0] = grid[0][0];
        deque.AddFirst((0, 0));

        while (deque.Count > 0) {
            var node = deque.First!.Value;
            deque.RemoveFirst();
            int r = node.r;
            int c = node.c;

            // Early stop: even best known path to this node already exhausts health.
            if (minDamage[r, c] >= health) {
                continue;
            }

            if (r == rows - 1 && c == cols - 1) {
                return true;
            }

            for (int k = 0; k < 4; k++) {
                int nr = r + dr[k];
                int nc = c + dc[k];
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) {
                    continue;
                }

                int w = grid[nr][nc];
                int nextDamage = minDamage[r, c] + w;
                if (nextDamage >= minDamage[nr, nc] || nextDamage >= health) {
                    continue;
                }

                minDamage[nr, nc] = nextDamage;
                if (w == 0) {
                    deque.AddFirst((nr, nc));
                } else {
                    deque.AddLast((nr, nc));
                }
            }
        }

        return false;
    }
}