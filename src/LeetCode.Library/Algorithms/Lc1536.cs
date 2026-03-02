namespace LeetCode.Library.Algorithms;

public class Lc1536Solution {
    public int MinSwaps(int[][] grid) {
        int n = grid.Length, res = 0;
        int[] row = new int[n];
        for (int i = 0; i < n; i++) {
            int trailingZeroCnt = 0;
            for (int j = n-1; j >= 0 && grid[i][j] == 0; j--) {
                trailingZeroCnt++;
            }
            row[i] = trailingZeroCnt;
        }
        for (int i = 0; i < n; i++) {
            int k = i;
            int req = n - 1 - i; // desired tailing zero count
            while (k < n && row[k] < req) {
                k++; // greedily find first swaping candidate and log the result into k
            }
            if (k == n) {
                return -1; // k is out of range. Fail in searching
            }

            // move k-th row up to i-th row
            res += k-i; // accumulate the operation cost of moving k to i
            // move the rest involved row downward by offset 1
            while (k > i) { // simulate swaping operation of two adjacent rows in range of [i, k-1]
                row[k] = row[k-1];
                k--;
            }
        } 
        return res;
    }
}