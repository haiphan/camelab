namespace LeetCode.Library.Algorithms;

public class Lc1404Solution {
    public int NumSteps(string s) {
        int cnt = 0;
        int carry = 0;
        int n = s.Length;
        for (int i = n - 1; i > 0; i--) {
            int d = s[i] - '0' + carry;
            if (d == 1) {
                carry = 1;
                cnt += 2;
            } else {
                cnt++;
            }
        }
        return cnt + carry;
    }
}