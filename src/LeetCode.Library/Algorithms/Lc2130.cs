using LeetCode.Library.DataStructures;

namespace LeetCode.Library.Algorithms;

public class Lc2130Solution {
    public int PairSum(ListNode head) {
        List<int> values = new List<int>();
        ListNode current = head;
        while (current != null) {
            values.Add(current.val);
            current = current.next;
        }
        
        int maxSum = 0;
        int n = values.Count;
        for (int i = 0; i < n / 2; i++) {
            int sum = values[i] + values[n - 1 - i];
            maxSum = Math.Max(maxSum, sum);
        }
        
        return maxSum;
    }
}