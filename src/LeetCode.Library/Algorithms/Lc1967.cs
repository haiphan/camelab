namespace LeetCode.Library.Algorithms;

public class Lc1967Solution {
    public int NumOfStrings(string[] patterns, string word) {
        int cnt = 0;
        foreach (string s in patterns) {
            if (word.Contains(s)) cnt++;
        }
        return cnt;
    }
}