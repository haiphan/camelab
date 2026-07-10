namespace LeetCode.Library.Algorithms;

public class Lc3534Solution {
    public int[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        int count = nums.Length;
        int[] answer = new int[queries.Length];

        if (count <= 1) {
            for (int i = 0; i < queries.Length; i++) {
                int u = queries[i][0];
                int v = queries[i][1];
                answer[i] = (u == v && u == 0 && count == 1) ? 0 : -1;
            }
            return answer;
        }

        int[] sortedValues = new int[count];
        int[] order = new int[count];
        for (int i = 0; i < count; i++) {
            sortedValues[i] = nums[i];
            order[i] = i;
        }
        Array.Sort(sortedValues, order);

        int[] sortedPos = new int[count];
        for (int i = 0; i < count; i++) {
            sortedPos[order[i]] = i;
        }

        int[] far = new int[count];
        int[] component = new int[count];
        int sweepRight = 0;
        for (int i = 0; i < count; i++) {
            if (sweepRight < i) {
                sweepRight = i;
            }
            while (sweepRight + 1 < count && (long)sortedValues[sweepRight + 1] - sortedValues[i] <= maxDiff) {
                sweepRight++;
            }
            far[i] = sweepRight;
            if (i > 0) {
                component[i] = component[i - 1] + (sortedValues[i] - sortedValues[i - 1] > maxDiff ? 1 : 0);
            }
        }

        int maxLog = 1;
        while ((1 << maxLog) <= count) {
            maxLog++;
        }

        int[][] jump = new int[maxLog][];
        jump[0] = new int[count];
        Array.Copy(far, jump[0], count);
        for (int level = 1; level < maxLog; level++) {
            jump[level] = new int[count];
            for (int i = 0; i < count; i++) {
                jump[level][i] = jump[level - 1][jump[level - 1][i]];
            }
        }

        for (int i = 0; i < queries.Length; i++) {
            int u = queries[i][0];
            int v = queries[i][1];

            if ((uint)u >= (uint)count || (uint)v >= (uint)count) {
                answer[i] = -1;
                continue;
            }

            if (u == v) {
                answer[i] = 0;
                continue;
            }

            int left = u;
            int right = v;
            if (left > right) {
                (left, right) = (right, left);
            }

            int from = sortedPos[left];
            int to = sortedPos[right];
            if (from > to) {
                (from, to) = (to, from);
            }

            if (from == to) {
                answer[i] = 0;
                continue;
            }

            if (component[from] != component[to]) {
                answer[i] = -1;
                continue;
            }

            int current = from;
            int steps = 0;
            for (int level = maxLog - 1; level >= 0; level--) {
                int next = jump[level][current];
                if (next < to) {
                    current = next;
                    steps += 1 << level;
                }
            }

            if (far[current] >= to) {
                answer[i] = steps + 1;
            } else {
                answer[i] = -1;
            }
        }

        return answer;
    }
}