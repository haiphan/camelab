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
                        // lcp[i][j] > 0 means res[i] and res[j] must be the same character
                        // because lcp[i][j] is the length of the longest common prefix of res[i..] and res[j..]
                        res[j] = res[i];
                    }
                }
                cur++;
            }
        }
        for (int i = n - 1; i >= 0; i--) {
            int[] row = lcp[i];
            for (int j = n - 1; j >= 0; j--) {
                int v = row[j];
                if (res[i] != res[j]) {
                    if (v > 0) return "";
                } else {
                    if (i == n - 1 || j == n - 1) {
                        if (v != 1) return "";
                    } else {
                        if (v != lcp[i + 1][j + 1] + 1) return "";
                    }
                }
            }
        }
        return new string(res);
    }
}