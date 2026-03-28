namespace LeetCode.Library.Algorithms;

public class Lc2573Solution {
    public string FindTheString(int[][] lcp) {
        int n = lcp.Length;
        char[] res = new char[n];
        char cur = 'a';
        for (int i = 0; i < n; i++) {
            if (res[i] == '\0') {
                if (cur > 'z') return "";
                res[i] = cur;
                for (int j = i + 1; j < n; j++) {
                    if (lcp[i][j] > 0) {
                        res[j] = res[i];
                    }
                }
                cur++;
            }
        }
        for (int i = n - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                if (res[i] != res[j]) {
                    if (lcp[i][j] > 0) return "";
                } else {
                    if (i == n - 1 || j == n - 1) {
                        if (lcp[i][j] != 1) return "";
                    } else {
                        if (lcp[i][j] != lcp[i + 1][j + 1] + 1) return "";
                    }
                }
            }
        }
        return new string(res);
    }
}