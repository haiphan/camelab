namespace LeetCode.Library.Algorithms;

public class Lc3016Solution {
    public int MinimumPushes(string word) {
        int[] count = new int[26];
        foreach (char c in word) {
            count[c - 'a']++;
        }

        Array.Sort(count);
        int answer = 0;
        for (int i = 25; i >= 0 && count[i] > 0; i--) {
            int pressCost = ((25 - i) / 8) + 1;
            answer += count[i] * pressCost;
        }

        return answer;
    }
}