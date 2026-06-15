using LeetCode.Library.DataStructures;

namespace LeetCode.Library.Algorithms;

public class Lc2095Solution {
    public ListNode DeleteMiddle(ListNode head) {
        if (head == null || head.next == null) {
            return null!;
        }

        ListNode? slow = head, fast = head, prev = null;
        while (fast != null && fast.next != null) {
            prev = slow;
            slow = slow!.next;
            fast = fast.next.next;
        }

        // Now 'slow' is at the middle node, and 'prev' is the node before it.
        prev!.next = slow!.next; // Skip the middle node

        return head;
    }
}