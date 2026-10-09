namespace LeetCode.Library.Algorithms;

public class Lc1541Solution {
    public int MinInsertions(string s) {
        var insertions = 0;
        var need = 0;
        foreach (var c in s) {
            if (c == '(') {
                need += 2;
                // A dangling single ')' requirement can't carry over an open; insert it now.
                if (need % 2 == 1) {
                    insertions++;
                    need--;
                }
            } else {
                need--;
                if (need == -1) {
                    insertions++;
                    need = 1;
                }
            }
        }
        return insertions + need;
    }
}