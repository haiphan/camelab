namespace LeetCode.Library.Algorithms;

public class Lc3568Solution {
    public int MinMoves(string[] classroom, int energy) {
        int rows = classroom.Length;
        int cols = classroom[0].Length;
        int startRow = 0, startCol = 0;
        int litterCount = 0;
        int[,] litterIndex = new int[rows, cols];
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                litterIndex[row, col] = -1;
                if (classroom[row][col] == 'S') {
                    startRow = row;
                    startCol = col;
                } else if (classroom[row][col] == 'L') {
                    litterIndex[row, col] = litterCount++;
                }
            }
        }

        if (litterCount == 0) {
            return 0;
        }

        int allLitter = (1 << litterCount) - 1;
        byte[,,] bestEnergy = new byte[rows, cols, 1 << litterCount];
        var queue = new Queue<(int Row, int Col, int Mask, int Energy, int Moves)>();
        bestEnergy[startRow, startCol, 0] = (byte)energy;
        queue.Enqueue((startRow, startCol, 0, energy, 0));

        int[] rowDelta = [-1, 1, 0, 0];
        int[] colDelta = [0, 0, -1, 1];
        while (queue.Count > 0) {
            var state = queue.Dequeue();
            for (int direction = 0; direction < 4; direction++) {
                int nextRow = state.Row + rowDelta[direction];
                int nextCol = state.Col + colDelta[direction];
                if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols || classroom[nextRow][nextCol] == 'X') {
                    continue;
                }

                int nextEnergy = state.Energy - 1;
                if (nextEnergy < 0) {
                    continue;
                }
                if (classroom[nextRow][nextCol] == 'R') {
                    nextEnergy = energy;
                }

                int nextMask = state.Mask;
                int litter = litterIndex[nextRow, nextCol];
                if (litter >= 0) {
                    nextMask |= 1 << litter;
                }
                if (nextMask == allLitter) {
                    return state.Moves + 1;
                }
                if (bestEnergy[nextRow, nextCol, nextMask] >= nextEnergy) {
                    continue;
                }

                bestEnergy[nextRow, nextCol, nextMask] = (byte)nextEnergy;
                queue.Enqueue((nextRow, nextCol, nextMask, nextEnergy, state.Moves + 1));
            }
        }

        return -1;
    }
}