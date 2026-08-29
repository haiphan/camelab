namespace LeetCode.Library.Algorithms;

public class Lc2948Solution {
    public int[] LexicographicallySmallestArray(int[] nums, int limit) {
        int n = nums.Length;
        List<List<int>> buckets = new List<List<int>>(n);
        Dictionary<int, int> vToGroup = new Dictionary<int, int>(n);
        int[] sortedNums = new int[n];
        Array.Copy(nums, sortedNums, n);
        Array.Sort(sortedNums);
        foreach (var num in sortedNums)
        {
            if (buckets.Count == 0 || num - buckets[buckets.Count - 1][^1] > limit)
            {
                buckets.Add(new List<int>());
            }
            buckets[buckets.Count - 1].Add(num);
            vToGroup[num] = buckets.Count - 1;
        }
        int[] gi = new int[buckets.Count];
        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            int groupIndex = vToGroup[num];
            int indexInGroup = gi[groupIndex];
            nums[i] = buckets[groupIndex][indexInGroup];
            gi[groupIndex]++;
        }
        return nums;
    }
}