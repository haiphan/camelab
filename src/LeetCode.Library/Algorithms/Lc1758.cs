namespace LeetCode.Library.Algorithms;

public class Lc1758Solution {
    public int MinOperations(string s) {
        int count = 0, n = s.Length;
        for (int i = 0; i < n; i++) {
            count += ((int)s[i] ^ i) & 1;
        }
        return Math.Min(count, n - count);
    }
}