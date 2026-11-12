namespace LeetCode.Library.Algorithms;

public class Lc3105Solution {
    public int LongestMonotonicSubarray(int[] nums) {
        int maxDec = 1;
        int maxInc = 1;
        int curDec = 1;
        int curInc = 1;
        int n = nums.Length;
        for (int i = 1; i < n; i++) {
            if (nums[i] == nums[i - 1]) {
                (curInc, curDec) = (1, 1);
            } else if (nums[i] > nums[i - 1]) {
                curInc++;
                curDec = 1;
            } else {
                curDec++;
                curInc = 1;
            }
            maxDec = Math.Max(maxDec, curDec);
            maxInc = Math.Max(maxInc, curInc);
        }
        return Math.Max(maxDec, maxInc);
    }
}