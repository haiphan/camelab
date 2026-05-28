namespace LeetCode.Library.Algorithms;


public class TrieNode {
    public int[] Children { get; } = new int[26];
    public int BestIndex { get; set; } = 1000000000;
    public int BestLength { get; set; } = 1000000000;
    public TrieNode()
    {
        Children.AsSpan().Fill(-1);
    }
}
public class Lc3093Solution {
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery) {
        List<TrieNode> trie = new() { new TrieNode() };
        int containerSize = wordsContainer.Length;
        for (int i = 0; i < containerSize; i++)
        {
            int len = wordsContainer[i].Length;
            int curr = 0;
            
            if (len < trie[curr].BestLength || (len == trie[curr].BestLength && i < trie[curr].BestIndex)) {
                trie[curr].BestLength = len;
                trie[curr].BestIndex = i;
            }
            for (int j = len - 1; j >= 0; j--) {
                int charIdx = wordsContainer[i][j] - 'a';
                
                if (trie[curr].Children[charIdx] == -1) {
                    trie[curr].Children[charIdx] = trie.Count;
                    trie.Add(new TrieNode());
                }
                
                curr = trie[curr].Children[charIdx];
                
                if (len < trie[curr].BestLength || (len == trie[curr].BestLength && i < trie[curr].BestIndex)) {
                    trie[curr].BestLength = len;
                    trie[curr].BestIndex = i;
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
                if (trie[curr].Children[charIdx] == -1) {
                    break;
                }
                curr = trie[curr].Children[charIdx];
            }
            ans[i] = trie[curr].BestIndex;
        }
        return ans;
    }
}