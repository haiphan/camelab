namespace LeetCode.Library.Algorithms;

public class Lc453Solution {
    public int MinMoves(int[] nums) {
        int n = nums.Length;
        int min = int.MaxValue;
        int sum = 0;
        foreach (var num in nums) {
            min = Math.Min(min, num);
            sum += num;
        }
        return sum - min * n;
    }
}