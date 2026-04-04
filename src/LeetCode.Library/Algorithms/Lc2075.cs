namespace LeetCode.Library.Algorithms;

public class Lc2075Solution {
    public string DecodeCiphertext(string encodedText, int rows) {
        int n = encodedText.Length;
        if (rows == 1) return encodedText;
        int cols = n / rows;
        char[] res = new char[n];
        int idx = 0;
        for (int c = 0; c < cols; c++) {
            int r = 0, cc = c;
            while (r < rows && cc < cols) {
                res[idx++] = encodedText[r * cols + cc];
                r++;
                cc++;
            }
        }
        while (idx > 0 && res[idx - 1] == ' ') {
            idx--;
        }
        return new string(res, 0, idx);
    }
}