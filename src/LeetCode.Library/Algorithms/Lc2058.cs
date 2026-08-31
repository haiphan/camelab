using LeetCode.Library.DataStructures;

namespace LeetCode.Library.Algorithms;

public class Lc2058Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        int index = 1;
        var prev = head;
        var curr = head.next;
        int firstIndex = -1;
        int lastIndex = -1;
        int minDistance = int.MaxValue;
        while (curr != null && curr.next != null) {
            if ((curr.val > prev.val && curr.val > curr.next.val) || (curr.val < prev.val && curr.val < curr.next.val)) {
                if (firstIndex == -1) {
                    firstIndex = index;
                } else {
                    minDistance = Math.Min(minDistance, index - lastIndex);
                }
                lastIndex = index;
            }
            prev = curr;
            curr = curr.next;
            index++;
        }

        if (firstIndex == -1 || firstIndex == lastIndex) return [-1, -1];
        return [minDistance, lastIndex - firstIndex];
    }
}