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
        // Always use the smaller array to build the prefix set
        int[] small, large;
        if (arr1.Length <= arr2.Length) {
            small = arr1;
            large = arr2;
        } else {
            small = arr2;
            large = arr1;
        }

        HashSet<int> prefixSet = new HashSet<int>();
        int maxPossible = 0;
        foreach (int num in small) {
            maxPossible = Math.Max(maxPossible, countDigits(num));
            int x = num;
            while (x > 0) {
                prefixSet.Add(x);
                x /= 10;
            }
        }

        int ans = 0;
        foreach (int num in large) {
            int x = num;
            int dc = countDigits(x);
            while (x > 0 && dc > ans) {
                if (prefixSet.Contains(x)) {
                    ans = dc;
                    if (ans == maxPossible) {
                        return ans;
                    }
                    break;
                }
                x /= 10;
                dc--;
            }
        }
        return ans;
    }
}