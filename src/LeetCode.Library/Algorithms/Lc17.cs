namespace LeetCode.Library.Algorithms;

public class Lc17Solution {
    public List<string> res = new();
    public int L = 0;
    public Dictionary<char, string> dMap = new Dictionary<char, string> {
        ['2'] = "abc",
        ['3'] = "def",
        ['4'] = "ghi",
        ['5'] = "jkl",
        ['6'] = "mno",
        ['7'] = "pqrs",
        ['8'] = "tuv",
        ['9'] = "wxyz",
    };
    public void dfs(int i, string cur, string digits) {
        if (i == L) {
            res.Add(cur);
            return;
        }
        string chars = dMap[digits[i]];
        for (int j = 0; j < chars.Length; j++) {
            dfs(i + 1, cur + chars[j], digits);
        }
    }    
    public IList<string> LetterCombinations(string digits) {
        L = digits.Length;
        dfs(0, "", digits);
        return res;
    }
}