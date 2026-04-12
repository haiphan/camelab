namespace LeetCode.Library.Algorithms;

public class Lc657Solution {
    private static readonly sbyte[] Dx = CreateDx();
    private static readonly sbyte[] Dy = CreateDy();

    private static sbyte[] CreateDx() {
        sbyte[] dx = new sbyte[128];
        dx['L'] = -1;
        dx['R'] = 1;
        return dx;
    }

    private static sbyte[] CreateDy() {
        sbyte[] dy = new sbyte[128];
        dy['D'] = -1;
        dy['U'] = 1;
        return dy;
    }

    public bool JudgeCircle(string moves) {
        int x = 0, y = 0;
        foreach (char move in moves) {
            int code = move;
            x += Dx[code];
            y += Dy[code];
        }
        return x == 0 && y == 0;
    }
}