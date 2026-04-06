namespace LeetCode.Library.Algorithms;

public class Lc874Solution {
    public readonly record struct Obs(int X, int Y);
    public int RobotSim(int[] commands, int[][] obstacles) {
        int m = commands.Length, n = obstacles.Length;
        int[][] dirs = [[0, 1], [1, 0], [0, -1], [-1, 0]];
        int di = 0, x = 0, y = 0, maxDistSq = 0;
        HashSet<Obs> obsSet = new();
        for (int i = 0; i < n; i++) {
            obsSet.Add(new Obs(obstacles[i][0], obstacles[i][1]));
        }
        for (int i = 0; i < m; i++) {
            int cmd = commands[i];
            if (cmd == -2) {
                di = (di + 3) % 4;
            } else if (cmd == -1) {
                di = (di + 1) % 4;
            } else {
                int[] dir = dirs[di];
                for (int step = 0; step < cmd; step++) {
                    int nextX = x + dir[0], nextY = y + dir[1];
                    if (obsSet.Contains(new Obs(nextX, nextY))) {
                        break;
                    }
                    x = nextX;
                    y = nextY;
                }
                maxDistSq = Math.Max(maxDistSq, x * x + y * y);
            }
        }
        return maxDistSq;
    }
}