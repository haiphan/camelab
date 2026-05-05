using LeetCode.Library.DataStructures;

namespace LeetCode.Library.Algorithms;

public class Lc61Solution {
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null || head.next == null || k <= 0) {
            return head;
        }

        // First, find the length of the list and the tail node.
        ListNode tail = head;
        int length = 1; // Start at 1 since we are already at head.
        while (tail.next != null) {
            tail = tail.next;
            length++;
        }

        // Connect the tail to the head to make it circular.
        tail.next = head;

        // Find the new tail: it will be (length - k % length - 1) steps from the current head.
        int stepsToNewTail = length - k % length - 1;
        ListNode newTail = head;
        for (int i = 0; i < stepsToNewTail; i++) {
            newTail = newTail.next!;
        }

        // The new head is the next node after the new tail.
        ListNode newHead = newTail.next!;

        // Break the circle by setting the new tail's next to null.
        newTail.next = null;

        return newHead;
    }
}