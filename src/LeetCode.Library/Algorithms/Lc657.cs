namespace LeetCode.Library.Algorithms;

public class Lc657Solution {
    private static int GetDx(char move) {
        int m = move;
        // bit3=1 for L, bit1=1 for R → isLR selects horizontal moves
        int isLR = ((m >> 3) | (m >> 1)) & 1;
        // m&2: R→2, L→0; (m&2)-1: R→+1, L→-1
        return ((m & 2) - 1) * isLR;
    }

    private static int GetDy(char move) {
        int m = move;
        int isLR = ((m >> 3) | (m >> 1)) & 1;
        // m&1: U→1, D→0; (m&1)*2-1: U→+1, D→-1
        return ((m & 1) * 2 - 1) * (1 - isLR);
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