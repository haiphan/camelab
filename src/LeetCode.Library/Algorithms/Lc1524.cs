namespace LeetCode.Library.Algorithms;

public class Lc1524Solution {
    public int NumOfSubarrays(int[] arr) {
            int MOD = 1_000_000_007;
            int n = arr.Length;
            int sum = 0;
            int oddCount = 0;
            foreach (var num in arr) {
                sum += num;
                oddCount += sum & 1;
            }
            // Use long for the multiplication to avoid int overflow when n is large.
            long result = (oddCount + (long)oddCount * (n - oddCount)) % MOD;
            return (int)result;
    }
}