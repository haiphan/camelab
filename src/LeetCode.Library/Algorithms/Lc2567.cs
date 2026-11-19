namespace LeetCode.Library.Algorithms;

public class Lc2567Solution {
    public int MinimizeSum(int[] nums) {
        int n = nums.Length;
        // small1, small2, small3, ..., large3, large2, large1
        int small1 = int.MaxValue, small2 = int.MaxValue, small3 = int.MaxValue;
        int large1 = int.MinValue, large2 = int.MinValue, large3 = int.MinValue;
        foreach (var num in nums)
        {
            if (num <= small1) { small3 = small2; small2 = small1; small1 = num; }
            else if (num <= small2) { small3 = small2; small2 = num; }
            else if (num <= small3) { small3 = num; }

            if (num >= large1) { large3 = large2; large2 = large1; large1 = num; }
            else if (num >= large2) { large3 = large2; large2 = num; }
            else if (num >= large3) { large3 = num; }
        }
        int rmTwoSmall = large1 - small3;
        int rmOneSmallOneLarge = large2 - small2;
        int rmTwoLarge = large3 - small1;
        return Math.Min(rmTwoSmall, Math.Min(rmOneSmallOneLarge, rmTwoLarge));
    }
}