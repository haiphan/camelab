namespace LeetCode.Library.Algorithms;

public class Lc3041Solution {
    public int MaxSelectedElements(int[] nums) {
        int best = 1;
        int keep = 1;
        int bump = 1;
        Array.Sort(nums);
        int last = -10;
        foreach (var num in nums)
        {
            int diff = num - last;
            switch (diff)
            {
                case 0:
                    bump = keep + 1;
                    break;
                case 1:
                    bump++;
                    keep++;
                    break;
                case 2:
                    keep = bump + 1;
                    bump = 1;
                    break;
                default:
                    keep = 1;
                    bump = 1;
                    break;
            }
            best = Math.Max(best, Math.Max(keep, bump));
            last = num;
        }
        return best;
    }
}