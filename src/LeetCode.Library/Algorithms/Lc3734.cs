namespace LeetCode.Library.Algorithms;

public class Lc3734Solution {
    public string LexPalindromicPermutation(string s, string target) {
        int n = s.Length;
        Span<int> counts = stackalloc int[26];
        foreach (char character in s) {
            counts[character - 'a']++;
        }

        // a palindrome permutation exists only if at most one character has an odd count,
        // and that is only allowed when n is odd (it becomes the middle character).
        bool isOdd = (n & 1) == 1;
        int middleChar = -1;
        int oddCount = 0;
        for (int c = 0; c < 26; c++) {
            if ((counts[c] & 1) != 0) {
                oddCount++;
                middleChar = c;
            }
        }
        if (isOdd ? oddCount != 1 : oddCount != 0) {
            return "";
        }

        int half = n / 2;
        Span<int> halfCounts = stackalloc int[26];
        for (int c = 0; c < 26; c++) {
            halfCounts[c] = counts[c] / 2;
        }

        // a palindrome is fully determined by its first `half` characters, so finding the
        // smallest palindrome > target reduces to finding the smallest arrangement of the
        // half-multiset that ties target's first `half` characters as long as possible.
        Span<int> bestRemaining = stackalloc int[26];
        int bestPosition = -1;
        int bestCharacter = -1;
        int matchedLength = 0;
        for (int position = 0; position < half; position++) {
            int targetIndex = target[position] - 'a';
            for (int candidate = targetIndex + 1; candidate < 26; candidate++) {
                if (halfCounts[candidate] > 0) {
                    halfCounts.CopyTo(bestRemaining);
                    bestPosition = position;
                    bestCharacter = candidate;
                    break;
                }
            }

            if (halfCounts[targetIndex] == 0) {
                break;
            }
            halfCounts[targetIndex]--;
            matchedLength++;
        }

        if (matchedLength == half) {
            char[] tieCandidate = new char[n];
            target.CopyTo(0, tieCandidate, 0, half);
            int idx = half;
            if (isOdd) {
                tieCandidate[idx++] = (char)('a' + middleChar);
            }
            for (int i = half - 1; i >= 0; i--) {
                tieCandidate[idx++] = tieCandidate[i];
            }
            string tieString = new string(tieCandidate);
            if (string.CompareOrdinal(tieString, target) > 0) {
                return tieString;
            }
        }

        if (bestPosition < 0) {
            return "";
        }

        bestRemaining[bestCharacter]--;
        char[] result = new char[n];
        target.CopyTo(0, result, 0, bestPosition);
        result[bestPosition] = (char)('a' + bestCharacter);
        int resultIndex = bestPosition + 1;
        for (int i = 0; i < 26; i++) {
            while (bestRemaining[i]-- > 0) {
                result[resultIndex++] = (char)('a' + i);
            }
        }
        if (isOdd) {
            result[resultIndex++] = (char)('a' + middleChar);
        }
        for (int i = half - 1; i >= 0; i--) {
            result[resultIndex++] = result[i];
        }
        return new string(result);
    }
}