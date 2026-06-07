namespace LeetCode.Library.Algorithms;

public class Lc1665Solution {
    public int MinimumEffort(int[][] tasks) {
        int n = tasks.Length;
        const int MaxDelta = 9999;
        int[] counts = new int[MaxDelta + 1];
        int minDelta = MaxDelta;
        int maxDelta = 0;

        // Counting sort by delta = minimum - actual in ascending order.
        foreach (int[] task in tasks) {
            int delta = task[1] - task[0];
            counts[delta]++;
            if (delta < minDelta) {
                minDelta = delta;
            }
            if (delta > maxDelta) {
                maxDelta = delta;
            }
        }

        for (int i = minDelta + 1; i <= maxDelta; i++) {
            counts[i] += counts[i - 1];
        }

        int[][] sortedTasks = new int[n][];
        for (int i = n - 1; i >= 0; i--) {
            int[] task = tasks[i];
            int delta = task[1] - task[0];
            sortedTasks[--counts[delta]] = task;
        }

        int ans = 0;
        foreach (int[] task in sortedTasks) {
            int actual = task[0];
            int minimum = task[1];
            ans = Math.Max(ans + actual, minimum);
        }

        return ans;
    }
}