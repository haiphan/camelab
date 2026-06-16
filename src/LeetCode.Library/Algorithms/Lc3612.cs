namespace LeetCode.Library.Algorithms;

public class Lc3612Solution {
    public string ProcessStr(string s) {
        List<char> result = new();
        foreach (char c in s) {
            if (c == '*')
            {
                if (result.Count > 0) {
                    result.RemoveAt(result.Count - 1);
                }
            } else if (c == '#') {
                // duplicate result
                result.AddRange(result);
            } else if (c == '%')
            {
                // reverse result
                result.Reverse();
            } else {
                result.Add(c);
            }
        }
        return new string(result.ToArray());
    }
}