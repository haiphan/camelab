namespace LeetCode.Library.Algorithms;

public class Lc3838Solution {
    public string MapWordWeights(string[] words, int[] weights) {
        int n = words.Length;
        char[] result = new char[n];
        for (int i = 0; i < n; i++) {
            int sum = 0;
            foreach (char c in words[i])
            {
                sum += weights[c - 'a'];
            }
            sum %= 26;
            result[i] = (char)('a' + 25 - sum);
        }
        return new string(result);
    }
}