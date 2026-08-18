namespace LeetCode.Library.Algorithms;

public class Lc3471Solution {
    public int LargestInteger(int[] nums, int k) {
        int n = nums.Length;
        int maxv = 0;
        int[] count = new int[51];
        foreach (int num in nums) {
            count[num]++;
            maxv = Math.Max(maxv, num);
        }
        if (k == n) {
            return maxv;
        }
        if (k == 1) {
            for (int i = maxv; i >= 0; i--) {
                if (count[i] == 1) {
                    return i;
                }
            }
        }
        int first = nums[0];
        int last = nums[n - 1];
        if (count[first] == 1 && count[last] == 1) {
            return Math.Max(first, last);
        }
        if (count[first] == 1) {
            return first;
        }
        if (count[last] == 1) {
            return last;
        }
        return -1;
    }
}