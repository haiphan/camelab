namespace LeetCode.Library.Algorithms;

public class Lc657Solution {
    private static int GetDx(char move) {
        int m = move;
        int bit1 = (m >> 1) & 1;
        int horizontalMask = ((m >> 3) & 1) | bit1;
        return ((bit1 << 1) - 1) * horizontalMask;
    }

    private static int GetDy(char move) {
        int m = move;
        int bit1 = (m >> 1) & 1;
        int horizontalMask = ((m >> 3) & 1) | bit1;
        int verticalMask = 1 - horizontalMask;
        return (((m & 1) << 1) - 1) * verticalMask;
    }

    public bool JudgeCircle(string moves) {
        int x = 0, y = 0;
        foreach (char move in moves) {
            x += GetDx(move);
            y += GetDy(move);
        }
        return x == 0 && y == 0;
    }
}