namespace LeetCode.Library.Algorithms;

public class Lc2904Solution {
    public string ShortestBeautifulSubstring(string s, int k) {
        if (k == 1) {
            return s.IndexOf('1') >= 0 ? "1" : "";
        }

        int n = s.Length;
        int left = 0;
        int oneCount = 0;
        int bestStart = -1;
        int minLength = int.MaxValue;
        for (int right = 0; right < n; right++) {
            if (s[right] == '1') {
                oneCount++;
            }

            while (oneCount > k) {
                if (s[left++] == '1') {
                    oneCount--;
                }
            }

            if (oneCount == k) {
                while (s[left] == '0') {
                    left++;
                }

                int length = right - left + 1;
                if (length == k) {
                    return s.Substring(left, length);
                }
                if (length < minLength ||
                    (length == minLength && string.CompareOrdinal(s, left, s, bestStart, length) < 0)) {
                    minLength = length;
                    bestStart = left;
                }
            }
        }

        return bestStart < 0 ? "" : s.Substring(bestStart, minLength);
    }
}