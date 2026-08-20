namespace LeetCode.Library.Algorithms;

public class Lc3069Solution {
    public int[] ResultArray(int[] nums) {
        int n = nums.Length;
        int[] arr1 = new int[n];
        int[] arr2 = new int[n];
        int len1 = 0, len2 = 0;
        arr1[len1++] = nums[0];
        arr2[len2++] = nums[1];
        for (int i = 2; i < n; i++) {
            if (arr1[len1 - 1] > arr2[len2 - 1]) {
                arr1[len1++] = nums[i];
            } else {
                arr2[len2++] = nums[i];
            }
        }
        int[] result = new int[n];
        Array.Copy(arr1, 0, result, 0, len1);
        Array.Copy(arr2, 0, result, len1, len2);
        return result;
    }
}