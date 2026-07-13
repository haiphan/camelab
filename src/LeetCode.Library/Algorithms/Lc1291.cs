namespace LeetCode.Library.Algorithms;

public class Lc1291Solution {
    public IList<int> SequentialDigits(int low, int high) {
        List<int> result = new List<int>();
        for (int length = 2; length <= 9; length++) {
            for (int start = 1; start <= 10 - length; start++) {
                int num = 0;
                for (int i = 0; i < length; i++) {
                    num = num * 10 + (start + i);
                }
                if (num >= low && num <= high) {
                    result.Add(num);
                }
            }
        }
        return result;
    }
}