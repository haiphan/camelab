namespace LeetCode.Library.Algorithms;

public class Lc874Solution {
    private sealed class LinearProbingSet {
        private readonly uint[] keys;
        private readonly bool[] used;
        private readonly int mask;

        public LinearProbingSet(int expectedCount) {
            int capacity = 1;
            int target = Math.Max(4, expectedCount * 4);
            while (capacity < target) {
                capacity <<= 1;
            }

            keys = new uint[capacity];
            used = new bool[capacity];
            mask = capacity - 1;
        }

        public void Add(uint key) {
            int idx = Hash(key);
            while (used[idx]) {
                if (keys[idx] == key) {
                    return;
                }
                idx = (idx + 1) & mask;
            }

            used[idx] = true;
            keys[idx] = key;
        }

        public bool Contains(uint key) {
            int idx = Hash(key);
            while (used[idx]) {
                if (keys[idx] == key) {
                    return true;
                }
                idx = (idx + 1) & mask;
            }
            return false;
        }

        private int Hash(uint key) {
            return (int)((key * 2654435761u) & (uint)mask);
        }
    }

    private static uint Encode(int x, int y) {
        const int shift = 30000;
        const int width = 60001;
        return (uint)((x + shift) * width + (y + shift));
    }

    public int RobotSim(int[] commands, int[][] obstacles) {
        int m = commands.Length, n = obstacles.Length;
        int[][] dirs = [[0, 1], [1, 0], [0, -1], [-1, 0]];
        int di = 0, x = 0, y = 0, maxDistSq = 0;
        LinearProbingSet obsSet = new(n);
        for (int i = 0; i < n; i++) {
            obsSet.Add(Encode(obstacles[i][0], obstacles[i][1]));
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
                    if (obsSet.Contains(Encode(nextX, nextY))) {
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