namespace LeetCode.Library.Algorithms;

public class Lc401Solution {
    public string getTimeStr(int x) {
        int h = x >> 6;
        int m = x & 63;
        if (h >= 12 || m >= 60) {
            return "";
        }
        string hs = h.ToString();
        string ms = m.ToString();
        if (m < 10) {
            ms = "0" + ms;
        }
        return hs + ":" + ms;
    }
    public IList<string> ReadBinaryWatch(int turnedOn) {
        int k = turnedOn;
        if (k == 0) {
            return ["0:00"];
        }
        if (k > 8) {
            return [];
        }
        int q = (1 << k) - 1;
        int UB = 1 << 10;
        List<string> ans = new(720);
        while (q < UB) {
            string ts = getTimeStr(q);
            if (ts != "") {
                ans.Add(ts);
            }
            int r = q & -q;
            int n = q + r;
            q = (((n ^ q) >> 2) / r) | n;
        }
        return ans;
    }
}