namespace LeetCode.Library.Algorithms;

public class Lc1385Solution {
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {
        int count = 0;
        foreach (var a in arr1) {
            bool valid = true;
            foreach (var b in arr2) {
                if (Math.Abs(a - b) <= d) {
                    valid = false;
                    break;
                }
            }
            if (valid) count++;
        }
        return count;
    }
}