namespace LeetCode.Library.Algorithms;

public class Lc3010Solution {
    public int MinimumCost(int[] nums) {
        int n = nums.Length;
        int min0 = nums[0];
        int min1 = 51;
        int min2 = 51;
        for(int i = 1; i < n; i++) {
            if(nums[i] < min1) {
                min2 = min1;
                min1 = nums[i];
            } else if(nums[i] < min2) {
                min2 = nums[i];
            }
        }
        return min0 + min1 + min2;
    }
}