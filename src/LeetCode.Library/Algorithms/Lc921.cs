namespace LeetCode.Library.Algorithms;

public class Lc921Solution {
    public int MinAddToMakeValid(string s) {
        int balance = 0;
        int result = 0;
        foreach (var c in s) {
            if (c == '(') {
                balance++;
            } else {
                balance--;
                if (balance < 0) {
                    result++;
                    balance = 0;
                }
            }
        }
        return result + balance;
    }
}