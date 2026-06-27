namespace LeetCode.Library.Algorithms;

public class Lc3020Solution {
    public int MaximumLength(int[] nums) {
        int n = nums.Length;
        var cm = new Dictionary<int, int>(n);
        int maxVal = 0;
        for (int i = 0; i < n; i++) {
            cm[nums[i]] = cm.GetValueOrDefault(nums[i], 0) + 1;
            if (nums[i] > maxVal) maxVal = nums[i];
        }

        int ans = 1;

        // Special handling for 1: since 1^2 == 1, we can use all ones.
        if (cm.TryGetValue(1, out int c1)) {
            ans = Math.Max(ans, c1);
        }

        var keys = new List<int>(cm.Keys);
        int sqrtMax = (int)Math.Sqrt(maxVal);

        foreach (int k in keys) {
            if (k == 1) continue;

            // Compute theoretical max chain length starting from k using maxVal.
            // Math.Log(maxVal)/Math.Log(k) > 1 is equivalent to k < maxVal.
            if (k == maxVal) continue;
            int levels = (int)Math.Floor(Math.Log(Math.Log(maxVal) / Math.Log(k), 2)) + 1;
            // Maximum achievable length from this start is at most 2*levels - 1.
            if (2 * levels - 1 <= ans) continue;

            // skip starts that are the square of a previous node with at least two copies
            int r = (int)Math.Sqrt(k);
            if (r * r == k && cm.TryGetValue(r, out int rCount) && rCount > 1) continue;

            int cur = k;
            int pairs = 0;

            // follow chain cur, cur^2, cur^(4), ... while nodes have at least two copies
            while (true) {
                if (!cm.TryGetValue(cur, out int cnt)) break;
                if (cnt > 1) {
                    // If cur is already larger than sqrt(maxVal), cur^2 can't exist in nums.
                    if (cur > sqrtMax) {
                        pairs++;
                        break;
                    }
                    pairs++;
                    // safe to square since cur <= sqrtMax implies cur*cur <= maxVal
                    cur = cur * cur;
                    continue;
                }
                // found a single copy endpoint
                int len = 2 * pairs + 1; // pairs produce 2*pairs, plus this single endpoint
                ans = Math.Max(ans, len);
                goto NextKey;
            }

            // no single endpoint found; length is 2*pairs - 1 (last pair contributes only one)
            int len2 = 2 * pairs - 1;
            if (len2 > 0) ans = Math.Max(ans, len2);

        NextKey: ;
        }

        // Ensure we return an odd length: if even, subtract 1.
        if ((ans & 1) == 0) ans--;
        return ans;
    }
}