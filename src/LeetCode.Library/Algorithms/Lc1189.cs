namespace LeetCode.Library.Algorithms;

public class Lc1189Solution {
    public int MaxNumberOfBalloons(string text) {
        int[] buckets = new int[26];
        foreach (char c in text) {
            buckets[c - 'a']++;
        }
        int ans = buckets['b' - 'a'];
        ans = Math.Min(ans, buckets['a' - 'a']);
        ans = Math.Min(ans, buckets['l' - 'a'] / 2);
        ans = Math.Min(ans, buckets['o' - 'a'] / 2);
        ans = Math.Min(ans, buckets['n' - 'a']);
        return ans;
    }
}