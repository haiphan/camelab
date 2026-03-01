namespace LeetCode.Library.Algorithms;

public class Lc1689Solution {
    public int MinPartitions(string n) {
        int ans = 0;
        int m = n.Length;
        for (int i = 0; i < m; i++) {
            ans = Math.Max(ans, n[i] - '0');
            if (ans == 9) {
                break;
            }
        }
        return ans;
    }
}