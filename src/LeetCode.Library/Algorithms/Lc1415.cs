namespace LeetCode.Library.Algorithms;

public class Lc1415Solution {
    public string GetHappyString(int n, int k) {
        if (n <= 0) {
            return "";
        }

        int total = 3 << (n - 1);
        if (k > total) {
            return "";
        }

        char[] ans = new char[n];
        char[] letters = ['a', 'b', 'c'];
        int remainingK = k;

        for (int i = 0; i < n; i++) {
            int blockSize = 1 << (n - i - 1);
            for (int j = 0; j < 3; j++) {
                char c = letters[j];
                if (i > 0 && ans[i - 1] == c) {
                    continue;
                }

                if (remainingK > blockSize) {
                    remainingK -= blockSize;
                    continue;
                }

                ans[i] = c;
                break;
            }
        }

        return new string(ans);
    }
}