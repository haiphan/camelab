namespace LeetCode.Library.Algorithms;

public class Lc3471Solution {
    public int LargestInteger(int[] nums, int k) {
        /*
        An integer x is almost missing from nums if x appears in exactly one subarray of size k within nums.
        Return the largest almost missing integer from nums. If no such integer exists, return -1.
        */
        int n = nums.Length;
        int[] count = new int[51];
        foreach (int num in nums) {
            count[num]++;
        }
        if (k == nums.Length) {
            for (int i = 50; i >= 0; i--) {
                if (count[i] > 0) {
                    return i;
                }
            }
            return -1;
        }
        if (k == 1) {
            for (int i = 50; i >= 0; i--) {
                if (count[i] == 1) {
                    return i;
                }
            }
            return -1;
        }
        n--;
        if (nums[0] == nums[n]) {
            return -1;
        }
        if (count[nums[0]] == 1 && count[nums[n]] == 1) {
            return Math.Max(nums[0], nums[n]);
        }
        if (count[nums[0]] == 1) {
            return nums[0];
        }
        if (count[nums[n]] == 1) {
            return nums[n];
        }
        return -1;
    }
}