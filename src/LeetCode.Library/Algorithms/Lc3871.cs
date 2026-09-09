namespace LeetCode.Library.Algorithms;

public class Lc3871Solution {
    public long CountCommas(long n) {
        if (n < 1000) return 0;
        long cap = 1000;
        int comma = 1;
        long ans = 0;
        while (n >= cap) {
            long next = cap * 1000;
            ans += comma * (Math.Min(n, next - 1) - cap + 1);
            cap = next;
            comma++;
        }
        return ans;
    }
}