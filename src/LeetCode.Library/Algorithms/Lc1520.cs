namespace LeetCode.Library.Algorithms;

public class Lc1520Solution {
    public IList<string> MaxNumOfSubstrings(string s) {
        int n = s.Length;
        int[] first = new int[26];
        int[] last = new int[26];
        Array.Fill(first, -1);

        for (int i = 0; i < n; i++) {
            int letter = s[i] - 'a';
            if (first[letter] == -1) first[letter] = i;
            last[letter] = i;
        }

        var result = new List<string>();
        int previousEnd = -1;
        for (int start = 0; start < n; start++) {
            int letter = s[start] - 'a';
            if (first[letter] != start) continue;

            int end = last[letter];
            bool valid = true;
            for (int i = start; i <= end; i++) {
                int current = s[i] - 'a';
                if (first[current] < start) {
                    valid = false;
                    break;
                }

                end = Math.Max(end, last[current]);
            }

            if (!valid) continue;
            string substring = s.Substring(start, end - start + 1);
            if (start > previousEnd) {
                result.Add(substring);
                previousEnd = end;
            } else if (end <= previousEnd) {
                result[^1] = substring;
                previousEnd = end;
            }
        }

        return result;
    }
}