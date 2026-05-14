namespace LeetCode.Library.Algorithms;

public class Lc2784Solution {
    public bool IsGood(int[] nums) {
        int m = nums.Length;
        int n = m - 1;
        bool[] seen = new bool[m];
        bool dup = false;
        foreach (int v in nums) {
            if (v > n) {
                return false;
            }
            if (seen[v]) {
                if (v < n || dup) {
                    return false;
                }
                dup = true;
                continue;
            }
            seen[v] = true;
        }
        return true;
    }
}