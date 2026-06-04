namespace LeetCode.Library.Algorithms;

public class Lc3043Solution {
    // Linear-probing hash set; 0 is the empty sentinel (all values >= 1)
    private int[] _table = [];
    private int _mask;

    // Next power of two >= n
    private static int NextPow2(int n) {
        if (n <= 1) return 1;
        return 1 << (32 - System.Numerics.BitOperations.LeadingZeroCount((uint)(n - 1)));
    }

    private static int Hash(int x) => (int)((uint)(x * 0x9e3779b9) >> 12); // Fibonacci hash → upper bits

    private void TableAdd(int x) {
        int h = Hash(x) & _mask;
        while (_table[h] != 0) {
            if (_table[h] == x) return;
            h = (h + 1) & _mask;
        }
        _table[h] = x;
    }

    private bool TableContains(int x) {
        int h = Hash(x) & _mask;
        while (_table[h] != 0) {
            if (_table[h] == x) return true;
            h = (h + 1) & _mask;
        }
        return false;
    }

    private static int CountDigits(int num) =>
        num < 10 ? 1 : num < 100 ? 2 : num < 1000 ? 3 : num < 10000 ? 4 :
        num < 100000 ? 5 : num < 1000000 ? 6 : num < 10000000 ? 7 :
        num < 100000000 ? 8 : 9;

    public int LongestCommonPrefix(int[] arr1, int[] arr2) {
        // Always use the smaller array to build the prefix table
        int[] small = arr1.Length <= arr2.Length ? arr1 : arr2;
        int[] large = arr1.Length <= arr2.Length ? arr2 : arr1;

        // Size table to ~40% load: max prefixes = small.Length * 8 digits
        int tableSize = NextPow2(small.Length * 20);
        _mask = tableSize - 1;
        _table = new int[tableSize];

        int maxPossible = 0;
        foreach (int num in small) {
            maxPossible = Math.Max(maxPossible, CountDigits(num));
            int x = num;
            while (x > 0) {
                TableAdd(x);
                x /= 10;
            }
        }

        int ans = 0;
        foreach (int num in large) {
            int x = num;
            int dc = CountDigits(x);
            while (x > 0 && dc > ans) {
                if (TableContains(x)) {
                    ans = dc;
                    if (ans == maxPossible) return ans;
                    break;
                }
                x /= 10;
                dc--;
            }
        }
        return ans;
    }
}