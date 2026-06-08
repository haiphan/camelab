namespace LeetCode.Library.Algorithms;

public class Lc1665Solution {
    public int MinimumEffort(int[][] tasks) {
        int n = tasks.Length;
        const int MaxDelta = 9999;
        int[] counts = new int[MaxDelta + 1];
        int minDelta = MaxDelta;
        int maxDelta = 0;
        int sumActual = 0;

        // Counting sort by delta = minimum - actual in ascending order.
        foreach (int[] task in tasks) {
            sumActual += task[0];
            int delta = task[1] - task[0];
            counts[delta]++;
            if (delta < minDelta) {
                minDelta = delta;
            }
            if (delta > maxDelta) {
                maxDelta = delta;
            }
        }

        // Prune: if all tasks have the same delta, ordering is irrelevant.
        if (minDelta == maxDelta) {
            return sumActual + minDelta;
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