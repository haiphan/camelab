namespace LeetCode.Library.Algorithms;

public class Lc2914Solution {
    public int MinChanges(string s) {
        int n = s.Length;
        int changes = 0;
        for (int i = 0; i < n; i += 2)
        {
            changes += (s[i] - '0') ^ (s[i + 1] - '0');
        }
        return changes;
    }
}