namespace LeetCode.Library.Algorithms;

public class Lc3420Solution {
    public long CountNonDecreasingSubarrays(int[] nums, int k) {
        int n = nums.Length;
        // Array-backed deque over [lo, hi): indices are pushed only at the front (lo),
        // so lo strictly decreases and hi strictly decreases, each slot is written once.
        int[] starts = new int[n];
        int lo = n, hi = n;
        long ans = 0, water = 0;
        int r = n - 1;
        for (int l = n - 1; l >= 0; l--) {
            int x = nums[l];
            while (lo < hi && nums[starts[lo]] <= x) {  // x floods the plateau that starts at the front
                int s = starts[lo];
                lo++;
                int end = lo < hi ? starts[lo] : r + 1;
                water += (long) (x - nums[s]) * (end - s);
            }
            starts[--lo] = l;
            while (water > k && hi > lo) {  // the right end leaves with its water
                int last = starts[hi - 1];
                water -= (long)nums[last] - nums[r];
                if (last == r) {
                    hi--;
                }
                r--;
            }
            ans += r - l + 1;
        }
        return ans;
    }
}