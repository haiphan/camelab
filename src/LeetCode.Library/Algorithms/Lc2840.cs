namespace LeetCode.Library.Algorithms;

public class Lc2840Solution {
    public bool CheckStrings(string s1, string s2) {
        int n = s1.Length;
        int[] cc = new int[52];
        for (int i = 0; i < n; i++)
        {
            int baseIndex = (i & 1) * 26;
            cc[baseIndex + (s1[i] - 'a')]++;
            cc[baseIndex + (s2[i] - 'a')]--;
        }
        if (cc.Any(x => x != 0)) return false;
        return true;
    }
}