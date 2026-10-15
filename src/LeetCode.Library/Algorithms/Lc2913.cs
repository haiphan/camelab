namespace LeetCode.Library.Algorithms;

public class Lc2913Solution {
    public int SumCounts(IList<int> nums) {
        int n = nums.Count;
        int ans = 0;
        bool[] seen = new bool[101];
        for (int i = 0; i < n; i++) {
            Array.Clear(seen);
            int c = 0;
            for (int j = i; j < n; j++) {
                if (!seen[nums[j]]) {
                    seen[nums[j]] = true;
                    c++;
                }
                ans += c * c;
            }
        }
        return ans;
    }
}