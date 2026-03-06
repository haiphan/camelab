namespace LeetCode.Library.Algorithms;

public class Lc1784Solution {
    public bool CheckOnesSegment(string s) {
        return !s.Contains("01");
    }
}