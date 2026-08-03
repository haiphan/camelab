namespace LeetCode.Library.Algorithms;

public class Lc1406Solution {
    public string StoneGameIII(int[] stoneValue) {
        int n = stoneValue.Length;
        int sufSum = 0;
        // f1, f2, f3 represent the maximum score difference for the next 1, 2, and 3 stones respectively
        int f1 = 0, f2 = 0, f3 = 0;
        for (int i = n - 1; i >= 0; i--) {
            sufSum += stoneValue[i];
            int f = Math.Max(sufSum - f1, Math.Max(sufSum - f2, sufSum - f3));
            f3 = f2;
            f2 = f1;
            f1 = f;
        }
        int diff = f1 - (sufSum - f1);
        if (diff > 0) {
            return "Alice";
        }
        if (diff < 0) {
            return "Bob";
        }
        return "Tie";
    }
}