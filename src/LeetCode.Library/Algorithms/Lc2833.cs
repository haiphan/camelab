namespace LeetCode.Library.Algorithms;

public class Lc2833Solution {
    public int FurthestDistanceFromOrigin(string moves) {
        int n = moves.Length;
        int lc = 0;
        int rc = 0;
        foreach (char move in moves) {
            int v = move;
            // 'L' = 76 (bit1=0, bit3=1), 'R' = 82 (bit1=1, bit3=0), '_' = 95 (bit1=1, bit3=1)
            lc += (~v >> 1) & 1;  // 1 only when bit1 is 0 → 'L'
            rc += (~v >> 3) & 1;  // 1 only when bit3 is 0 → 'R'
        }
        int fc = n - lc - rc;
        return Math.Max(Math.Abs(lc - rc - fc), Math.Abs(lc - rc + fc));
    }
}