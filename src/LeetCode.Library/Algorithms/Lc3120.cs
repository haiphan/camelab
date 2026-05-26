namespace LeetCode.Library.Algorithms;

public class Lc3120Solution {
    public int NumberOfSpecialChars(string word) {
        int n = word.Length;
        int count = 0;
        int[] freq = new int[26];
        for (int i = 0; i < n; i++) {
            int code = word[i] - 'a';
            if (code >= 0 && code < 26) {
                freq[code] |= 1;
            } else
            {
                code = word[i] - 'A';
                freq[code] |= 2;
            }
        }
        for (int i = 0; i < 26; i++) {
            count += freq[i] == 3 ? 1 : 0;
        }
        return count;
    }
}