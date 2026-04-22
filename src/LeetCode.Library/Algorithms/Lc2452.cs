namespace LeetCode.Library.Algorithms;

public class Lc2452Solution {
    public IList<string> TwoEditWords(string[] queries, string[] dictionary) {
        int n = queries[0].Length;
        int m = queries.Length;
        List<string> ans = new();
        for (int i = 0; i < m; i++) {
            string w = queries[i];
            foreach (string d in dictionary) {
                int diff = 0;
                for (int j = 0; j < n; j++) {
                    if (w[j] != d[j]) {
                        diff++;
                        if (diff > 2) {
                            break;
                        }
                    }
                }
                if (diff <= 2) {
                    ans.Add(w);
                    break;
                }
            }
        }
        return ans;
    }
}