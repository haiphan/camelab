namespace LeetCode.Library.Algorithms;

public class Lc3498Solution {
    public int ReverseDegree(string s) {
        int result = 0;
        for (int i = s.Length - 1; i >= 0; i--) {
            int v = 26 - (s[i] - 'a');
            result += (i + 1) * v;
        }
        return result;
    }
}