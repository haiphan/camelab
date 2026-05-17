namespace LeetCode.Library.Algorithms;

public class Lc1306Solution {
    public bool CanReach(int[] arr, int start) {
        int n = arr.Length;
        if (arr[start] == 0) {
            return true;
        }

        bool[] seen = new bool[n];
        Queue<int> q = new Queue<int>();
        seen[start] = true;
        q.Enqueue(start);

        while (q.Count > 0) {
            int i = q.Dequeue();
            int left = i - arr[i];
            if (left >= 0 && !seen[left]) {
                if (arr[left] == 0) {
                    return true;
                }
                seen[left] = true;
                q.Enqueue(left);
            }

            int right = i + arr[i];
            if (right < n && !seen[right]) {
                if (arr[right] == 0) {
                    return true;
                }
                seen[right] = true;
                q.Enqueue(right);
            }
        }

        return false;
    }
}