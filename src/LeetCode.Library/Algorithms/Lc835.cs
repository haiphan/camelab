namespace LeetCode.Library.Algorithms;

public class Lc835Solution {
    public int LargestOverlap(int[][] img1, int[][] img2) {
        var n = img1.Length;
        var maxOverlap = 0;

        for (var rowShift = -n + 1; rowShift < n; rowShift++) {
            var rowStart = Math.Max(0, -rowShift);
            var rowEnd = Math.Min(n, n - rowShift);
            for (var columnShift = -n + 1; columnShift < n; columnShift++) {
                var columnStart = Math.Max(0, -columnShift);
                var columnEnd = Math.Min(n, n - columnShift);
                var overlap = 0;

                for (var row = rowStart; row < rowEnd; row++) {
                    for (var column = columnStart; column < columnEnd; column++) {
                        overlap += img1[row][column] * img2[row + rowShift][column + columnShift];
                    }
                }

                maxOverlap = Math.Max(maxOverlap, overlap);
            }
        }

        return maxOverlap;
    }
}