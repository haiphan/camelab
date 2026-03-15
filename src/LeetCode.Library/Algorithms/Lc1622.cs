namespace LeetCode.Library.Algorithms;

public class Lc1622Solution {
    public int a = 1;
    public int b = 0;
    public List<int> arr = new List<int>(100000);
    public int mod = 1000000007;
    public void Append(int val) {
        long v = (val - b + mod) % mod;
        v = v * ArithmeticUtils.PowMod(a, mod - 2, mod) % mod;
        arr.Add((int)v);
    }
    
    public void AddAll(int inc) {
        b = (b + inc) % mod;
    }
    
    public void MultAll(int m) {
        a = (int)((long)a * m % mod);
        b = (int)((long)b * m % mod);
    }
    
    public int GetIndex(int idx) {
        if (idx >= arr.Count) {
            return -1;
        }
        return (int)(((long)arr[idx] * a + b) % mod);
    }
}