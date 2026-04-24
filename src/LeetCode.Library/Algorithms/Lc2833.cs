namespace LeetCode.Library.Algorithms;

public class Lc2833Solution {
    public int FurthestDistanceFromOrigin(string moves) {
        int n = moves.Length;
        int lc = 0;
        int rc = 0;
        foreach (char move in moves) {
            if (move == 'L') {
                lc++;
            } else if (move == 'R') {
                rc++;
            }
        }
        int fc = n - lc - rc;
        return Math.Max(Math.Abs(lc - rc - fc), Math.Abs(lc - rc + fc));
    }
}