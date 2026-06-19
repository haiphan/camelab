namespace LeetCode.Library.Algorithms;

public class Lc1732Solution {
    public int LargestAltitude(int[] gain) {
        int ans = 0, cur = 0;
        foreach (int g in gain) {
            cur += g;
            ans = Math.Max(ans, cur);
        }
        return ans;
    }
}