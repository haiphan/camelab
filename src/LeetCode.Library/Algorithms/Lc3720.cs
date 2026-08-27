namespace LeetCode.Library.Algorithms;

public class Lc3720Solution {
    public string LexGreaterPermutation(string s, string target) {
        int n = s.Length;
        int[] counts = new int[26];
        foreach (char character in s) {
            counts[character - 'a']++;
        }

        int[] bestRemaining = new int[26];
        int bestPosition = -1;
        int bestCharacter = -1;
        for (int position = 0; position < n; position++) {
            int targetIndex = target[position] - 'a';
            for (int candidate = targetIndex + 1; candidate < 26; candidate++) {
                if (counts[candidate] > 0) {
                    Array.Copy(counts, bestRemaining, 26);
                    bestPosition = position;
                    bestCharacter = candidate;
                    break;
                }
            }

            if (counts[targetIndex] == 0) {
                break;
            }
            counts[targetIndex]--;
        }

        if (bestPosition < 0) {
            return "";
        }

        bestRemaining[bestCharacter]--;
        char[] result = new char[n];
        target.CopyTo(0, result, 0, bestPosition);
        result[bestPosition] = (char)('a' + bestCharacter);
        int resultIndex = bestPosition + 1;
        for (int i = 0; i < bestRemaining.Length; i++) {
            while (bestRemaining[i]-- > 0) {
                result[resultIndex++] = (char)('a' + i);
            }
        }
        return new string(result);
    }
}