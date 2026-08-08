namespace LeetCode.Library.Algorithms;

public class Lc3302Solution {
    public int[] ValidSequence(string word1, string word2) {
        int n = word1.Length;
        int m = word2.Length;
        if (m > n) {
            return [];
        }

        int[] last = new int[m];
        Array.Fill(last, -1);
        int j = m - 1;
        for (int i = n - 1; i >= 0 && j >= 0; i--) {
            if (word1[i] == word2[j]) {
                last[j] = i;
                j--;
            }
        }

        int[] ans = new int[m];
        int iPtr = 0;
        int jPtr = 0;
        bool usedChange = false;

        while (iPtr < n && jPtr < m) {
            if (word1[iPtr] == word2[jPtr]) {
                ans[jPtr++] = iPtr++;
                continue;
            }

            bool canUseChange = !usedChange &&
                (jPtr == m - 1 || (last[jPtr + 1] != -1 && iPtr < last[jPtr + 1]));
            if (canUseChange) {
                ans[jPtr++] = iPtr++;
                usedChange = true;
                continue;
            }

            iPtr++;
        }

        return jPtr == m ? ans : [];
    }
}