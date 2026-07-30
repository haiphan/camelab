namespace LeetCode.Library.Algorithms;

public class Lc3014Solution {
    public int MinimumPushes(string word) {
        int[] count = new int[26];
        foreach (char c in word) {
            count[c - 'a']++;
        }

        int[] bucket = new int[word.Length + 1];
        for (int i = 0; i < 26; i++) {
            int freq = count[i];
            if (freq > 0) {
                bucket[freq]++;
            }
        }

        int answer = 0;
        int usedLetters = 0;

        for (int freq = word.Length; freq >= 1; freq--) {
            int lettersAtFreq = bucket[freq];
            while (lettersAtFreq > 0) {
                int pressCost = (usedLetters / 8) + 1;
                answer += freq * pressCost;
                usedLetters++;
                lettersAtFreq--;
            }
        }

        return answer;
    }
}