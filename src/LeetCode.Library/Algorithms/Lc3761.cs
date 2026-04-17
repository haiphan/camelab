namespace LeetCode.Library.Algorithms;

public class Lc3761Solution {
    public int ReverseInt(int x) {
        int result = 0;
        while (x != 0)
        {
            int digit = x % 10;
            result = result * 10 + digit;
            x /= 10;
        }
        return result;
    }
    public int MinMirrorPairDistance(int[] nums) {
        int n = nums.Length;
        Dictionary<int, int> positions = new(n);
        int ans = n;
        for (int i = 0; i < n; i++)
        {
            if (positions.TryGetValue(nums[i], out int pos))
            {
                ans = Math.Min(ans, i - pos);
                if (ans == 1) {
                    return 1;
                }
            }
            positions[ReverseInt(nums[i])] = i;
        }
        return ans == n ? -1 : ans;
    }
}