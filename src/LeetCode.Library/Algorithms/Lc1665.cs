namespace LeetCode.Library.Algorithms;

public class Lc1665Solution {
    public int MinimumEffort(int[][] tasks) {
        int n = tasks.Length;
        // sort by min[i] - actual[i]
        Array.Sort(tasks, (a, b) => (a[1] - a[0]).CompareTo(b[1] - b[0]));
        int ans = 0;
        foreach (var task in tasks) {
            int actual = task[0];
            int minimum = task[1];
            ans = Math.Max(ans + actual, minimum);
        }
        return ans;
    }
}