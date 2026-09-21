namespace LeetCode.Library.Algorithms;

public class Lc3524Solution {
    public long[] ResultArray(int[] nums, int k) {
        long[] res = new long[k];
        int[] freq = new int[k];
        int[] next = new int[k];

        foreach (int n in nums) {
            int m = n % k;
            if (m == 0) {
                int count = 1;
                for (int x = 0; x < k; x++)
                {
                    count += freq[x];
                }

                res[0] += count;
                Array.Clear(freq, 1, k - 1);
                freq[0] = count;
                continue;
            }

            if (m == 1) {
                freq[1]++;
                for (int x = 0; x < k; x++)
                {
                    res[x] += freq[x];
                }

                continue;
            }

            next[m] = 1;

            for (int x = 0; x < k; x++) {
                next[x * m % k] += freq[x];
            }

            (freq, next) = (next, freq);
            for (int x = 0; x < k; x++) {
                res[x] += freq[x];
            }

            Array.Clear(next);
        }

        return res;
    }
}