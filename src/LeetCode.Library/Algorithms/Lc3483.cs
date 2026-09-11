namespace LeetCode.Library.Algorithms;

public class Lc3483Solution {
    public int TotalNumbers(int[] digits) {
        var freq = new int[10];
        foreach (var d in digits) {
            freq[d]++;
        }

        var distinctCount = 0;
        for (var d = 0; d <= 9; d++) {
            if (freq[d] > 0) distinctCount++;
        }

        var count = 0;
        for (var h = 1; h <= 9; h++) {
            if (freq[h] == 0) continue;
            for (var u = 0; u <= 8; u += 2) {
                if (freq[u] == 0) continue;

                if (h == u) {
                    // Both h and u already consume 2 copies of this digit; the tens slot is
                    // any other distinct digit, or this digit again if a 3rd copy exists.
                    if (freq[h] < 2) continue;
                    count += (freq[h] >= 3 ? 1 : 0) + (distinctCount - 1);
                } else {
                    // The tens slot is any other distinct digit, or h/u again if a spare copy exists.
                    count += (freq[h] >= 2 ? 1 : 0) + (freq[u] >= 2 ? 1 : 0) + (distinctCount - 2);
                }
            }
        }

        return count;
    }
}