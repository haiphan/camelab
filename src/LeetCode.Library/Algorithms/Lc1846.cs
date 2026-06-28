namespace LeetCode.Library.Algorithms;

public class Lc1846Solution {
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr) {
        int n = arr.Length;
        var freq = new int[n + 1];

        foreach (int x in arr) {
            if (x > n) {
                freq[n]++;
            } else {
                freq[x]++;
            }
        }

        int ans = 0;
        for (int x = 1; x <= n; x++) {
            int count = freq[x];
            if (count == 0) continue;

            if (x > ans + 1) {
                int needed = x - ans - 1;
                int use = count < needed ? count : needed;
                ans += use;
                count -= use;
            }

            if (count > 0) {
                ans = x;
            }
        }

        return ans;
    }
}