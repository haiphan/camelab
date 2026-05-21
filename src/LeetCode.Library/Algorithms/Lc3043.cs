namespace LeetCode.Library.Algorithms;

public class Lc3043Solution {
    private int countDigits(int num) {
        // use log10 to count the number of digits in num
        if (num == 0) {
            return 1;
        }
        return (int)Math.Log10(num) + 1;
    }
    public int LongestCommonPrefix(int[] arr1, int[] arr2) {
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in arr1) {
            int x = num;
            while (x > 0) {
                seen.Add(x);
                x /= 10;
            }
        }

        int ans = 0;
        foreach (int num in arr2) {
            int x = num;
            int dc = countDigits(x);
            // Only check prefixes longer than current ans
            while (x > 0 && dc > ans) {
                if (seen.Contains(x)) {
                    ans = dc;
                    break;
                }
                x /= 10;
                dc--;
            }
        }
        return ans;
    }
}