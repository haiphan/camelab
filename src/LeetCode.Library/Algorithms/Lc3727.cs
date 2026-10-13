namespace LeetCode.Library.Algorithms;

public class Lc3727Solution {
    public long MaxAlternatingSum(int[] nums) {
        int n = nums.Length;
        int[] cm = new int[40001];
        long ans = 0;
        foreach (int x in nums) {
            int v = Math.Abs(x);
            cm[v]++;
            ans += (long)v * v;
        }
        int rmCnt = n >> 1;
        for (int x = 0; x <= 40000 && rmCnt > 0; x++) {
            if (cm[x] > 0) {
                int remove = Math.Min(cm[x], rmCnt);
                ans -= (long)remove * x * x * 2;
                rmCnt -= remove;
            }
        }
        return ans;
    }
}