namespace LeetCode.Library.Algorithms;
using System.Numerics;

public class Lc1356Solution {
    public int[] SortByBits(int[] arr) {
        Array.Sort(arr, (a, b) => {
            int al = BitOperations.PopCount((uint)a);
            int bl = BitOperations.PopCount((uint)b);
            if (al == bl) return a.CompareTo(b);
            return al.CompareTo(bl);
        });
        return arr;
    }
}