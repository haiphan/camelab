namespace LeetCode.Library.Algorithms;

public class Lc3886Solution {
    public int SortableIntegers(int[] nums) {
        int n = nums.Length;
        int[] prefMax = new int[n];
        int[] sufMin = new int[n];
        int[] descPrefix = new int[n]; // descPrefix[i] = count of descents among pairs (0,1)..(i-1,i)

        prefMax[0] = nums[0];
        for (int i = 1; i < n; i++) {
            prefMax[i] = Math.Max(prefMax[i - 1], nums[i]);
            descPrefix[i] = descPrefix[i - 1] + (nums[i - 1] > nums[i] ? 1 : 0);
        }

        sufMin[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            sufMin[i] = Math.Min(sufMin[i + 1], nums[i]);
        }

        int sum = 0;
        for (int i = 1; i * i <= n; i++) {
            if (n % i != 0)
            {
                continue;
            }

            int j = n / i;
            if (IsGood(nums, prefMax, sufMin, descPrefix, i))
            {
                sum += i;
            }

            if (j != i && IsGood(nums, prefMax, sufMin, descPrefix, j))
            {
                sum += j;
            }
        }
        return sum;
    }

    private static bool IsGood(int[] nums, int[] prefMax, int[] sufMin, int[] descPrefix, int k) {
        int n = nums.Length;

        // Adjacent blocks' value ranges must not overlap, else no assignment of block
        // rotations can produce a globally non-decreasing array.
        for (int boundary = k; boundary < n; boundary += k) {
            if (prefMax[boundary - 1] > sufMin[boundary])
            {
                return false;
            }
        }

        // A block can be rotated into sorted order only if it has at most one cyclic descent:
        // internal descents come from the prefix-sum lookup, plus the wrap pair (last, first).
        for (int start = 0; start < n; start += k) {
            int end = start + k - 1;
            int descents = descPrefix[end] - descPrefix[start];
            if (nums[end] > nums[start])
            {
                descents++;
            }

            if (descents > 1)
            {
                return false;
            }
        }
        return true;
    }
}