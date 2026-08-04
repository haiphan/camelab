namespace LeetCode.Library.Algorithms;

public class Lc3731Solution {
    public IList<int> FindMissingElements(int[] nums) {
        int n = nums.Length;
        if (n == 1) return new List<int> {};
        bool[] present = new bool[101];
        int minv = nums[0], maxv = nums[0];
        foreach (int num in nums) {
            present[num] = true;
            if (num < minv) minv = num;
            if (num > maxv) maxv = num;
        }
        List<int> missing = new List<int>();
        for (int i = minv; i < maxv; i++) {
                if (!present[i]) {
                    missing.Add(i);
                }
        }
        return missing;
    }
}