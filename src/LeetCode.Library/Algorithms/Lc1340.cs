namespace LeetCode.Library.Algorithms;

public class Lc1340Solution {
    public int MaxJumps(int[] arr, int d) {
                int n = arr.Length;
        int[] indices = Enumerable.Range(0, n).ToArray();
        Array.Sort(indices, (a, b) => arr[a].CompareTo(arr[b]));
        int[] dp = new int[n];

        int ans = 1;
        foreach (int index in indices) {
            int best = 1;

            for (int next = index - 1; next >= 0 && next >= index - d; next--) {
                if (arr[next] >= arr[index]) {
                    break;
                }
                best = Math.Max(best, 1 + dp[next]);
            }

            for (int next = index + 1; next < n && next <= index + d; next++) {
                if (arr[next] >= arr[index]) {
                    break;
                }
                best = Math.Max(best, 1 + dp[next]);
            }

            dp[index] = best;
            ans = Math.Max(ans, best);
        }

        return ans;
    }
}