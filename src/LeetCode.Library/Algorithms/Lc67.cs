namespace LeetCode.Library.Algorithms;
using System.Text;

public class Lc67Solution {
    public string AddBinary(string a, string b) {
        int AL = a.Length;
        int BL = b.Length;
        int ML = Math.Max(AL, BL);
        var sb = new StringBuilder(ML + 1); 
        int c = 0;
        for (int i = 0; i < ML; i++) {
            int ia = AL - 1 - i;
            int ib = BL - 1 - i;
            int va = 0, vb = 0;
            if (ia >= 0) {
                va = a[ia]  - '0';
            }
            if (ib >= 0) {
                vb = b[ib]  - '0';
            }
            int d = va + vb + c;
            c = 0;
            if (d > 1) {
                c = 1;
                d &= 1;
            }
            sb.Append(d);
        }
        if (c == 1) {
            sb.Append('1');
        }
        int l = 0, r = sb.Length - 1;
        while (l < r) {
            (sb[l], sb[r]) = (sb[r], sb[l]);
            l++;
            r--;
        }
        return sb.ToString();
    }
}