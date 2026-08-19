namespace LeetCode.Library.Algorithms;

public class Lc1386Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {
        Dictionary<int, int> reserved = new();
        foreach (var seat in reservedSeats) {
            int row = seat[0];
            int col = seat[1];
            reserved[row] = reserved.GetValueOrDefault(row) | 1 << (col - 1);
        }

        int totalFamilies = 2 * (n - reserved.Count);
        foreach (int cols in reserved.Values) {
            int families = 0;
            // Check if we can place a family in the left block (seats 2-5) or right block (seats 6-9)
            bool canPlaceLeft = (cols & 0b0000011110) == 0;
            bool canPlaceRight = (cols & 0b0111100000) == 0;
            if (canPlaceLeft) {
                families++;
            }
            if (canPlaceRight) {
                families++;
            }
            // Check if we can place a family in the middle block (seats 4-7) if neither left nor right blocks are available
            if (families == 0 && (cols & 0b0001111000) == 0) {
                families = 1;
            }
            totalFamilies += families;
        }

        return totalFamilies;
    }
}