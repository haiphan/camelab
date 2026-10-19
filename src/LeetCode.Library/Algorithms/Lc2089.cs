namespace LeetCode.Library.Algorithms;

public class Lc2089Solution {
    public IList<int> TargetIndices(int[] nums, int target) {
        int n = nums.Length;
        int lessCnt = 0;
        int equalCnt = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] < target)
            {
                lessCnt++;
            }
            else if (nums[i] == target)
            {
                equalCnt++;
            }
        }
        var result = new List<int>(equalCnt);
        for (int i = 0; i < equalCnt; i++) {
            result.Add(lessCnt + i);
        }
        return result;
    }
}