namespace LeetCode.Library.Algorithms;

public class Lc3474Solution {
    public string GenerateString(string str1, string str2) {
        int n = str1.Length, m = str2.Length;
        char[] res = new char[n + m - 1];
        bool[] used = new bool[n + m - 1];
        for (int i = 0; i < res.Length; i++) {
            res[i] = 'a';
        }
        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'T') {
                for (int j = i; j < i + m; j++) {
                    if (used[j] && res[j] != str2[j - i]) return "";
                    res[j] = str2[j - i];
                    used[j] = true;
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'F') {
                int idx = -1;
                bool hasDiff = false;
                for (int j = i + m - 1; j >= i; j--) {
                    if (str2[j - i] != res[j]) {
                        hasDiff = true;
                    }
                    if (idx == -1 && !used[j]) {
                        idx = j;
                    }
                }
                if (hasDiff) continue;
                if (idx == -1) return "";
                res[idx] = 'b';
            }
        }
        return new string(res);
    }
}