namespace LeetCode.Library.Algorithms;

public class Lc1331Solution {
    public int[] ArrayRankTransform(int[] arr) {
        int n = arr.Length;
        if (n == 0) {
            return [];
        }

        int[] sortedIdx = new int[n];
        for (int i = 0; i < n; i++) {
            sortedIdx[i] = i;
        }

        Array.Sort(sortedIdx, (a, b) => arr[a].CompareTo(arr[b]));

        int[] result = new int[n];
        int rank = 1;
        result[sortedIdx[0]] = rank;

        for (int i = 1; i < n; i++) {
            if (arr[sortedIdx[i]] != arr[sortedIdx[i - 1]]) {
                rank++;
            }

            result[sortedIdx[i]] = rank;
        }

        return result;
    }
}