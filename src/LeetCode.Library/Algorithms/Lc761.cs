namespace LeetCode.Library.Algorithms;

public class Lc761Solution {
    public string MakeLargestSpecial(string s) {
        if (s == "") return "";
        int n = s.Length;
        List<string> ans = new(n);
        int diff = 0, start = 0;

        for (int i = 0; i < n; i++) {
            if (s[i] == '1') {
                diff++;
            } else {
                diff--;
            }
            if (diff == 0) {
                string inner = s.Substring(start + 1, i - start - 1);
                inner = MakeLargestSpecial(inner);
                ans.Add("1" + inner + "0");
                start = i + 1;
            }
        }
        ans.Sort((a, b) => string.Compare(b, a, StringComparison.Ordinal));

        return string.Join("", ans);
    }
}