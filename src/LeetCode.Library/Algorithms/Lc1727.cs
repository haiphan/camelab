namespace LeetCode.Library.Algorithms;

public class Lc1727Solution {
    public int LargestSubmatrix(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        int ans = 0;
        int[] hc = Array.Empty<int>();

        for (int i = 1; i < m; i++) {
            for (int j = 0; j < n; ++j) {
                matrix[i][j] *= matrix[i - 1][j] + 1;
            }
        }

		// view each row and its above as pillars 
        for(int i = 0; i < m; i++){
            int[] row = matrix[i];
            int minHeight = int.MaxValue;
            int maxHeight = 0;
            for (int j = 0; j < n; j++) {
                int h = row[j];
                if (h < minHeight) {
                    minHeight = h;
                }
                if (h > maxHeight) {
                    maxHeight = h;
                }
            }

            // Best possible area in this row cannot exceed maxHeight * n.
            if (maxHeight * n <= ans) {
                continue;
            }

            int rangeLen = maxHeight - minHeight + 1;
            if (hc.Length < rangeLen) {
                hc = new int[rangeLen];
            } else {
                Array.Clear(hc, 0, rangeLen);
            }

            for (int j = 0; j < n; j++) {
                hc[row[j] - minHeight]++;
            }

			// iterate heights from high to low; width is number of columns with height >= current height.
            int width = 0;
            for (int idx = rangeLen - 1; idx >= 0; idx--) {
                int h = minHeight + idx;
                if (h * n <= ans) {
                    break;
                }

                width += hc[idx];
                int area = h * width;
                if (area > ans) {
                    ans = area;
                }
            }
        }
        return ans;
    }
}