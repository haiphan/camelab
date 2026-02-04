namespace LeetCode.Library.Algorithms;

public class Lc3640Solution {
    public long MaxSumTrionic(int[] nums) {
        int n = nums.Length;
        long SMALL = (long)(-1e18);
        long ans, inc1, dec, inc2;
        (ans, inc1, dec, inc2) = (SMALL, SMALL, SMALL, SMALL);
        for (int i = 1; i < n; i++) {
            int cur = nums[i];
            int prev = nums[i - 1];
            long nextInc1, nextDec, nextInc2;
            (nextInc1, nextDec, nextInc2) = (SMALL, SMALL, SMALL);
            if (cur > prev) {
                long val1 = SMALL;
                if (inc1 > SMALL) {
                    val1 = inc1 + cur;
                }
                long val2 = prev + cur;
                if (val1 > val2) {
                    nextInc1 = val1;
                } else {
                    nextInc1 = val2;
                }
                // extend inc2
                long val3 = SMALL;
                if (inc2 > SMALL) {
                    val3 = inc2 + cur;
                }
                // switch from dec to inc2
                long val4 = SMALL;
                if (dec > SMALL) {
                    val4 = dec + cur;
                }
                if (val3 > val4) {
                    nextInc2 = val3;
                } else {
                    nextInc2 = val4;
                }

                // dec cannot be extended or started with an increasing pair
                nextDec = SMALL;
            } else if (cur < prev) {
                // extend dec
                long val1 = SMALL;
                if (dec > SMALL) {
                    val1 = dec + cur;
                }
                // switch from inc1 to dec
                long val2 = SMALL;
                if (inc1 > SMALL) {
                    val2 = inc1 + cur;
                }
                if (val1 > val2) {
                    nextDec = val1;
                } else {
                    nextDec = val2;
                }
                (nextInc1, nextInc2) = (SMALL, SMALL);
            }
            (inc1, dec, inc2) = (nextInc1, nextDec, nextInc2);
            if (inc2 > ans) {
                ans = inc2;
            }
        }
        return ans;
    }
}