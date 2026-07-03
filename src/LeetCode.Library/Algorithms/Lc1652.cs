namespace LeetCode.Library.Algorithms;

public class Lc1652Solution {
    public int[] Decrypt(int[] code, int k) {
        int n = code.Length;
        int[] ans = new int[n];
        if (k == 0) return ans;
        // sliding window
        int u = Math.Abs(k);
        int sum = 0;
        for (int i = 0; i < u; i++) {
            sum += code[i];
        }
        int ci = k > 0 ? n - 1 : u;
        for (int i = 0; i < n; i++) {
            ans[ci] = sum;
            sum -= code[i];
            sum += code[(i + u) % n];
            ci = (ci + 1) % n;
        }
        return ans;
    }
}