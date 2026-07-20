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
            int currentIndex = c - 'a';
            count[currentIndex]--;
            if (inStack[currentIndex]) {
                continue;
            }
            while (stack.Count > 0) {
                char top = stack.Peek();
                int topIndex = top - 'a';
                if (top <= c || count[topIndex] == 0) {
                    break;
                }
                stack.Pop();
                inStack[topIndex] = false;
            }
            stack.Push(c);
            inStack[currentIndex] = true;
        }
        char[] result = new char[stack.Count];
        for (int i = result.Length - 1; i >= 0; i--) {
            result[i] = stack.Pop();
        }
        return new string(result);
    }
}