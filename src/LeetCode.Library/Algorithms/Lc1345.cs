namespace LeetCode.Library.Algorithms;

public class Lc1345Solution {
    public int MinJumps(int[] arr) {
        int n = arr.Length;
        if (n <= 1) {
            return 0;
        }

        int last = n - 1;
        Dictionary<int, int> head = new Dictionary<int, int>();
        int[] next = new int[n];
        for (int i = 0; i < n; i++) {
            next[i] = -1;
            if (head.TryGetValue(arr[i], out int first)) {
                next[i] = first;
            }
            head[arr[i]] = i;
        }

        bool[] seen = new bool[n];

        Queue<int> queue = new Queue<int>(n);
        queue.Enqueue(0);
        seen[0] = true;

        void EnqueueIfUnseen(int index) {
            if (!seen[index]) {
                seen[index] = true;
                queue.Enqueue(index);
            }
        }

        int steps = 0;
        while (queue.Count > 0) {
            int levelCount = queue.Count;
            for (int i = 0; i < levelCount; i++) {
                int cur = queue.Dequeue();
                int value = arr[cur];
                if (cur == last) {
                    return steps;
                }

                if (cur - 1 >= 0 && !seen[cur - 1]) {
                    EnqueueIfUnseen(cur - 1);
                }

                if (cur + 1 < n && !seen[cur + 1]) {
                    EnqueueIfUnseen(cur + 1);
                }

                if (head.TryGetValue(value, out int first)) {
                    for (int nextIndex = first; nextIndex != -1; nextIndex = next[nextIndex]) {
                        EnqueueIfUnseen(nextIndex);
                    }

                    // Once a value has been expanded, it never needs to be scanned again.
                    head.Remove(value);
                }
            }

            steps++;
        }

        return -1;
    }
}