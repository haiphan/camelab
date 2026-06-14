using LeetCode.Library.DataStructures;

namespace LeetCode.Library.Algorithms;

public class Lc2130Solution {
    public int PairSum(ListNode head) {
        // Find midpoint while reversing first half in-place
        ListNode prev = null, slow = head, fast = head;
        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            ListNode next = slow.next;
            slow.next = prev;
            prev = slow;
            slow = next;
        }
        // prev: head of reversed first half, slow: head of second half

        // Walk both halves to find max twin sum
        int maxSum = 0;
        while (slow != null) {
            maxSum = Math.Max(maxSum, prev.val + slow.val);
            prev = prev.next;
            slow = slow.next;
        }

        return maxSum;
    }
}