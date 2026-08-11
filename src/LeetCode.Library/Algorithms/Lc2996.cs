namespace LeetCode.Library.Algorithms;

public class Lc2996Solution {
    public int MissingInteger(int[] nums) {
        HashSet<int> numSet = new HashSet<int>(nums);
        int sum = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] == nums[i - 1] + 1) {
                sum += nums[i];
            } else {
                break;
            }
        }
        while (numSet.Contains(sum)) {
            sum++;
        }
        return sum;
    }
}