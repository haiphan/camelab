namespace LeetCode.Library.Algorithms;

public class Lc3870Solution {
    public int CountCommas(int n) {
        if (n < 1000) return 0;
        int cap = 1000;
        int comma = 1;
        int ans = 0;
        while (n >= cap) {
            int next = cap * 1000;
            ans += Math.Min(n, next - 1) - cap + 1;
            cap = next;
            comma++;
        }
        return ans;
    }
}