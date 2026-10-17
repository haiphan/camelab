namespace LeetCode.Library.Algorithms;

public class Lc3551Solution {
    // n <= 1e5 fits in 17 bits; nums[i] <= 1e9 fits in 31 bits; digit sum (<=81) fits above both.
    private const int IndexBits = 17;
    private const int ValueBits = 31;
    private const long IndexMask = (1L << IndexBits) - 1;

    private int DigitSum(int x) {
        int sum = 0;
        while (x > 0) {
            sum += x % 10;
            x /= 10;
        }
        return sum;
    }
    public int MinSwaps(int[] nums) {
        int n = nums.Length;
        // Pack (DigitSum, Value, Index) into one long so Array.Sort uses the fast primitive-array path.
        var keys = new long[n];
        for (int i = 0; i < n; i++) {
            long dsum = DigitSum(nums[i]);
            keys[i] = (dsum << (IndexBits + ValueBits)) | ((long)nums[i] << IndexBits) | (uint)i;
        }
        Array.Sort(keys);

        var target = new int[n];
        for (int i = 0; i < n; i++) {
            target[i] = (int)(keys[i] & IndexMask);
        }

        int cnt = 0;
        int idx = 0;
        while (idx < n) {
            if (target[idx] != idx) {
                cnt++;
                int j = target[idx];
                (target[idx], target[j]) = (target[j], target[idx]);
            } else {
                idx++;
            }
        }
        return cnt;
    }
}