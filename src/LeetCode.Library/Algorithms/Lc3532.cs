namespace LeetCode.Library.Algorithms;

public class Lc3532Solution {
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        int[] prefix = new int[n];
        for (int i = 1; i < n; i++) {
            prefix[i] = prefix[i - 1] + (nums[i] - nums[i - 1] <= maxDiff ? 0 : 1);
        }
        bool[] ans = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            int left = queries[i][0];
            int right = queries[i][1];
            ans[i] = prefix[right] == prefix[left];
        }
        return ans;
    }
}