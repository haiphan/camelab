namespace LeetCode.Library.Algorithms;

public class Lc796Solution {
    public bool RotateString(string s, string goal) {
        int n = s.Length;
        if (n != goal.Length) {
            return false;
        }
        // Check if goal is a rotation of s by concatenating s with itself and checking for goal as a substring.
        return (s + s).Contains(goal);
    }
}