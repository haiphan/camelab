namespace LeetCode.Library.Algorithms;

public class Lc1569Solution {
    private int MOD = 1_000_000_007;
    private int[] Fact = new int[1001];
    public Lc1569Solution() {
        Fact[0] = 1;
        for (int i = 1; i <= 1000; i++) {
            Fact[i] = (int)((long)Fact[i - 1] * i % MOD);
        }
    }
    private int Pow(int x, int y) {
        int result = 1;
        while (y > 0) {
            if ((y & 1) == 1) result = (int)((long)result * x % MOD);
            x = (int)((long)x * x % MOD);
            y >>= 1;
        }
        return result;
    }
    public int NumOfWays(int[] nums) {
        int n = nums.Length;
        int[] insertTime = new int[n + 2];
        for (int i = 0; i < n + 2; i++)
        {
            insertTime[i] = -1;
        }
        for (int i = 0; i < n; i++)
        {
            insertTime[nums[i]] = i;
        }
        long sizes = 1;
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        for (int i = 1; i < n + 2; i++)
        {
            while (stack.Count > 0 && insertTime[stack.Peek()] > insertTime[i])
            {
               stack.Pop();
               // The raw subtree-size product can exceed int32/int64 range for large n, so reduce mod MOD each step.
               // sizes is the product of the sizes of all subtrees encountered so far, modulo MOD.
               sizes = sizes * (i - stack.Peek() - 1) % MOD;
            }
            stack.Push(i);
        }
        // Total arrangements producing the same BST = n! / sizes; exclude the original array itself.
        long totalWays = (long)Fact[n] * Pow((int)sizes, MOD - 2) % MOD;
        return (int)((totalWays - 1 + MOD) % MOD);
    }
}