namespace LeetCode.Library.Algorithms;

public class Lc20Solution {
    // Opening brackets map to positive ids, closings to their negated match; indexed directly by char code.
    private static readonly int[] Values = new int['}' + 1];

    static Lc20Solution() {
        Values['('] = 1; Values[')'] = -1;
        Values['['] = 2; Values[']'] = -2;
        Values['{'] = 3; Values['}'] = -3;
    }

    public bool IsValid(string s) {
        var stack = new Stack<int>();
        foreach (var c in s) {
            var v = Values[c];
            if (v > 0) {
                stack.Push(v);
            } else if (stack.Count == 0 || stack.Pop() + v != 0) {
                return false;
            }
        }
        return stack.Count == 0;
    }
}