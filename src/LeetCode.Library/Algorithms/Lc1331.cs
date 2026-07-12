namespace LeetCode.Library.Algorithms;

public class Lc1331Solution {
    public int[] ArrayRankTransform(int[] arr) {
        int n = arr.Length;
        int[] sortedArr = new int[n];
        Array.Copy(arr, sortedArr, n);
        Array.Sort(sortedArr);

        Dictionary<int, int> rankMap = new Dictionary<int, int>();
        int rank = 1;
        foreach (int num in sortedArr) {
            if (!rankMap.ContainsKey(num)) {
                rankMap[num] = rank++;
            }
        }

        int[] result = new int[n];
        for (int i = 0; i < n; i++) {
            result[i] = rankMap[arr[i]];
        }

        return result;
    }
}