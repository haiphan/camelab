using System.Runtime.InteropServices;

namespace LeetCode.Library.Algorithms;

public class Lc2958Solution {
    public int MaxSubarrayLength(int[] nums, int k) {
        int l = 0;
        Dictionary<int, int> count = new();
        int ans = 0;
        for (int r = 0; r < nums.Length; r++) {
            ref int frequency = ref CollectionsMarshal.GetValueRefOrAddDefault(count, nums[r], out _);
            frequency++;
            while (frequency > k) {
                count[nums[l]]--;
                l++;
            }
            ans = Math.Max(ans, r - l + 1);
            if (ans >= nums.Length - l) {
                return ans;
            }
        }
        return ans;
    }
}