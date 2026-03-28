namespace LeetCode.Library.Algorithms;

public class Lc2573Solution {
    public string FindTheString(int[][] lcp) {
        int n = lcp.Length;
        char[] res = new char[n];
        int id = -1;
        for (int i = 0; i < n; i++)
        {
            if (lcp[i][i] != n - i) return "";
            if (res[i] != '\0') continue;
            if (id >= 25) return "";
            char currentChar = (char)('a' + ++id);
            for (int j = i; j < n; j++)
            {
                int commonPrefix = lcp[i][j];
                if (commonPrefix != lcp[j][i] || commonPrefix > n - j) return "";
                if (commonPrefix > 0)
                {
                    if (res[j] != '\0' && res[j] != currentChar) return "";
                    res[j] = currentChar;
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int x = lcp[i][j];
                if (lcp[j][i] != x || x + i > n) return "";
                int y = i < n - 1 ? lcp[i + 1][j + 1] : 0;
                y = res[i] == res[j] ? y + 1 : 0;
                if (x != y) return "";
            }
        }
        return new string(res);
    }
}