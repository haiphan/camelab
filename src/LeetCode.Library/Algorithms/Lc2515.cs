namespace LeetCode.Library.Algorithms;

public class Lc2515Solution {
    public int ClosestTarget(string[] words, string target, int startIndex) {
        int n = words.Length;
        int half = n >> 1;
        for (int d = 0; d <= half; d++) {
            if (words[(startIndex - d + n) % n] == target) return d;
            if (words[(startIndex + d) % n] == target) return d;
        }
        return -1;
    }
}