namespace LeetCode.Library.Algorithms;

public class Lc3867Solution {
    private int GCD(int a, int b) {
        while (b != 0) {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
    public long GcdSum(int[] nums) {
        int maxv = 0;
        int n = nums.Length;
        for(int i=0; i<n; i++){
            maxv = Math.Max(maxv, nums[i]);
            nums[i] = GCD(nums[i], maxv);
        }
        Array.Sort(nums);
        int l = 0;
        int r = n - 1;
        long ans = 0;
        while (l < r) {
            ans += GCD(nums[l], nums[r]);
            l++;
            r--;
        }
        return ans;
    }
}