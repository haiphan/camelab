namespace LeetCode.Library.Algorithms;

public class Lc1927Solution {
    public bool SumGame(string num) {
        int n = num.Length;
        int n2 = n / 2;
        int diff = 0;
        for(int i = 0; i < n; i++){
            char c = num[i];
            bool isq = c=='?', half = i < n2;
            int sgn = half ? -1 : 1;
            int isqNum = isq ? 1 : 0;
            int d = (-isqNum & 9) + (-(1 - isqNum) & (c-'0')<<1);
            diff += sgn * d;
        }
        return diff!=0;
    }
}