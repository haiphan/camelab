namespace LeetCode.Library.Algorithms;

public class Lc1081Solution {
    public string SmallestSubsequence(string s) {
        int[] count = new int[26];
        bool[] inStack = new bool[26];
        foreach (char c in s) {
            count[c - 'a']++;
        }
        Stack<char> stack = new Stack<char>();
        foreach (char c in s) {
            count[c - 'a']--;
            if (inStack[c - 'a']) {
                continue;
            }
            while (stack.Count > 0 && stack.Peek() > c && count[stack.Peek() - 'a'] > 0) {
                inStack[stack.Pop() - 'a'] = false;
            }
            stack.Push(c);
            inStack[c - 'a'] = true;
        }
        char[] result = new char[stack.Count];
        for (int i = result.Length - 1; i >= 0; i--) {
            result[i] = stack.Pop();
        }
        return new string(result);
    }
}