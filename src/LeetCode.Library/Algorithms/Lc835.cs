namespace LeetCode.Library.Algorithms;

public class Lc835Solution {
    public int LargestOverlap(int[][] img1, int[][] img2) {
        int n = img1.Length;
        int maxOverlap = 0;
        for (int xShift = -n + 1; xShift < n; xShift++) {
            for (int yShift = -n + 1; yShift < n; yShift++) {
                int overlap = 0;
                for (int i = 0; i < n; i++) {
                    for (int j = 0; j < n; j++) {
                        int ni = i + xShift;
                        int nj = j + yShift;
                        if (ni >= 0 && ni < n && nj >= 0 && nj < n && img1[i][j] == 1 && img2[ni][nj] == 1) {
                            overlap++;
                        }
                    }
                }
                maxOverlap = Math.Max(maxOverlap, overlap);
            }
        }
        return maxOverlap;
    }
}