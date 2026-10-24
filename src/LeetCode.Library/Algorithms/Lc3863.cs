namespace LeetCode.Library.Algorithms;

public class Lc3863Solution {
    public int MinOperations(string s) {
        int n = s.Length;
        // Check if the string is already non-decreasing
        bool isGood = true;

        for(int i=0;i<n;i++) {
            if(i > 0 && s[i] < s[i - 1]) {
                isGood = false;
                break;
            }
        }
        if(isGood) {
            return 0;
        }
        if(n == 2) {
            return -1;
        }

        char minChar = 'z';
        char maxChar = 'a';

        foreach(char ch in s) {
            if (ch < minChar)
            {
                minChar = ch;
            }
            if (ch > maxChar)
            {
                maxChar = ch;
            }
        }

        if(minChar == s[0] || maxChar == s[n - 1]) {
            return 1;
        }
        for(int i = 1;i < n - 1;i++) {
            if(s[i] == minChar || s[i] == maxChar) {
                return 2;
            }
        }
        return 3;
    }
}