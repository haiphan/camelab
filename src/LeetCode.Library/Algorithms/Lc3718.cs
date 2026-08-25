namespace LeetCode.Library.Algorithms;

public class Lc3718Solution {
    public int MissingMultiple(int[] nums, int k) {
        bool [] present = new bool[101];
        foreach (int num in nums) {
            present[num] = true;
        }
        int cur = k;
        while (cur <= 100) {
            if (!present[cur]) {
                return cur;
            }
            cur += k;
        }
        return cur;
    }
}