namespace LeetCode.Library.Algorithms;

public class Lc3548Solution {
    public int version = 0;
    public int[] seen = new int[100001];
    public bool Solve1D(int[] arr, long total) {
        int n = arr.Length;
        long pref = 0;
        int first = arr[0], last = arr[n - 1];
        for (int i = 0; i < n - 1; i++) {
            pref += arr[i];
            long suff = total - pref;
            if (pref == suff) return true;
            long diff = pref - suff;
            if (diff > 0)
            {
                if (diff == first || diff == arr[i]) return true;
            } else {
                diff = -diff;
                if (diff == last || diff == arr[i + 1]) return true;
            }
        }
        return false;
    }
    public bool Solve2D(int[] flat, long[] rowSums, long total, int idx, int step, int maxv) {
        int m = rowSums.Length, n = flat.Length / m;
        version++;
        long pref = 0;
        for (int i = 0; i < m - 1; i++)
        {
            idx += step;
            pref += rowSums[idx];
            int offset = idx * n;
            for (int j = 0; j < n; j++)
            {
                seen[flat[offset + j]] = version;
            }
            long suff = total - pref;
            if (pref == suff) return true;
            if (pref < suff) continue;
            long diff = pref - suff;
            if (diff > maxv) break;
            if ((seen[(int)diff] == version && i > 0) || flat[offset] == diff || flat[offset + n - 1] == diff) return true;
        }
        return false;
    }
    public bool CanPartitionGrid(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        if (m == 1) {
            long sum = 0;
            for (int i = 0; i < n; i++) sum += grid[0][i];
            return Solve1D(grid[0], sum);
        }
        if (n == 1) {
            int[] col = new int[m];
            long sum = 0;
            for (int i = 0; i < m; i++)
            {
                col[i] = grid[i][0];
                sum += col[i];  
            } 
            return Solve1D(col, sum);
        }
        int[] flat = new int[m * n];
        long[] rowSums = new long[m];
        long total = 0;
        int maxv = 0, k = 0;
        for (int i = 0; i < m; i++) {
            long sum = 0;
            for (int j = 0; j < n; j++)
            {
                flat[k++] = grid[i][j];
                maxv = Math.Max(maxv, grid[i][j]);
                sum += grid[i][j];
            }
            rowSums[i] = sum;
            total += sum;
        }
        if (Solve2D(flat, rowSums, total, -1, 1, maxv) || Solve2D(flat, rowSums, total, m, -1, maxv)) return true;
        // transpose 
        k = 0;
        rowSums = new long[n];
        for (int j = 0; j < n; j++) {
            long sum = 0;
            for (int i = 0; i < m; i++)
            {
                flat[k++] = grid[i][j];
                sum += grid[i][j];
            }
            rowSums[j] = sum;
        }
        return Solve2D(flat, rowSums, total, -1, 1, maxv) || Solve2D(flat, rowSums, total, n, -1, maxv);
    }
}