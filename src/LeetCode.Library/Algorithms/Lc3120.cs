namespace LeetCode.Library.Algorithms;

public class Lc3120Solution {
    public int NumberOfSpecialChars(string word) {
        int n = word.Length;
        int count = 0;
        int[] freq = new int[26];
        for (int i = 0; i < n; i++) {
            int code = (word[i] | 32) - 'a';
            int bit = word[i] <= 'Z' ? 2 : 1;
            freq[code] |= bit;
        }
        for (int i = 0; i < 26; i++) {
            count += freq[i] == 3 ? 1 : 0;
        }
        return count;
    }
}