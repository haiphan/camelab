namespace LeetCode.Library.Algorithms;

public class Lc2657Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        int n = A.Length, count = 0;
        int[] res = new int[n];
        bool[] seen = new bool[n + 1];

        for (int i = 0; i < n; i++) {
            int a = A[i], b = B[i];
            if (seen[a]) count++;
            else seen[a] = true;

            if (seen[b]) count++;
            else seen[b] = true;

            res[i] = count;
        }

        return res;
    }
}