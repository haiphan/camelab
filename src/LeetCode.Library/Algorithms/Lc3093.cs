namespace LeetCode.Library.Algorithms;


public class Lc3093Solution {
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery) {
        const int AlphabetSize = 26;
        const int NotFound = -1;

        int totalChars = 0;
        foreach (string word in wordsContainer)
        {
            totalChars += word.Length;
        }

        int capacity = totalChars + 1;
        int[] children = new int[capacity * AlphabetSize];
        Array.Fill(children, NotFound);

        int[] bestIndex = new int[capacity];
        int[] bestLength = new int[capacity];
        Array.Fill(bestIndex, int.MaxValue);
        Array.Fill(bestLength, int.MaxValue);

        int nextNode = 1;
        int containerSize = wordsContainer.Length;
        for (int i = 0; i < containerSize; i++)
        {
            string word = wordsContainer[i];
            int len = word.Length;
            int curr = 0;

            if (len < bestLength[curr] || (len == bestLength[curr] && i < bestIndex[curr])) {
                bestLength[curr] = len;
                bestIndex[curr] = i;
            }

            for (int j = len - 1; j >= 0; j--) {
                int charIdx = word[j] - 'a';
                int childSlot = curr * AlphabetSize + charIdx;

                if (children[childSlot] == NotFound) {
                    children[childSlot] = nextNode;
                    nextNode++;
                }

                curr = children[childSlot];

                if (len < bestLength[curr] || (len == bestLength[curr] && i < bestIndex[curr])) {
                    bestLength[curr] = len;
                    bestIndex[curr] = i;
                }
            }
        }

        int[] ans = new int[wordsQuery.Length];
        for (int i = 0; i < wordsQuery.Length; i++)
        {
            int curr = 0;
            string query = wordsQuery[i];
            int len = query.Length;

            for (int j = len - 1; j >= 0; j--) {
                int charIdx = query[j] - 'a';
                int next = children[curr * AlphabetSize + charIdx];
                if (next == NotFound) {
                    break;
                }
                curr = next;
            }

            ans[i] = bestIndex[curr];
        }

        return ans;
    }
}