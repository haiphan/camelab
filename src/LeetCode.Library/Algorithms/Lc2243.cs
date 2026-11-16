namespace LeetCode.Library.Algorithms;

public class Lc2243Solution {
    private string SumDigits(string s) {
        int sum = 0;
        foreach (var c in s) {
            sum += c - '0';
        }
        return sum.ToString();
    }
    public string DigitSum(string s, int k) {
        while (s.Length > k) {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < s.Length; i += k) {
                var chunk = s.Substring(i, Math.Min(k, s.Length - i));
                sb.Append(SumDigits(chunk));
            }
            s = sb.ToString();
        }
        return s;
    }
}