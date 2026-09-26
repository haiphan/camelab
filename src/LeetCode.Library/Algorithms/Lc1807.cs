namespace LeetCode.Library.Algorithms;

public class Lc1807Solution {
    public string Evaluate(string s, IList<IList<string>> knowledge) {
        var dict = new Dictionary<string, string>();
        foreach (var kv in knowledge) {
            dict[kv[0]] = kv[1];
        }

        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                int j = i + 1;
                while (s[j] != ')') j++;
                var key = s[(i + 1)..j];
                sb.Append(dict.TryGetValue(key, out string? value) ? value : "?");
                i = j;
            } else {
                sb.Append(s[i]);
            }
        }
        return sb.ToString();
    }
}