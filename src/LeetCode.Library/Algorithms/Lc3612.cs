namespace LeetCode.Library.Algorithms;

public class Lc3612Solution {
    public string ProcessStr(string s) {
        char[] result = new char[Math.Max(4, EstimateMaxLength(s))];
        int length = 0;

        foreach (char c in s) {
            switch (c) {
                case '*':
                    if (length > 0) length--;
                    break;
                case '#':
                    if (length > 0) {
                        Array.Copy(result, 0, result, length, length);
                        length *= 2;
                    }
                    break;
                case '%':
                    Array.Reverse(result, 0, length);
                    break;
                default:
                    result[length++] = c;
                    break;
            }
        }

        return new string(result, 0, length);
    }

    private static int EstimateMaxLength(string s) {
        if (s.Length == 0) {
            return 0;
        }

        if (s.Length == 1) {
            return 1;
        }

        return 1 << (s.Length - 1);
    }
}