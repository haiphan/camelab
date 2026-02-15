namespace LeetCode.Library.DataStructures;
public class ListCodec {
    public ListNode CreateList(int[] nums) {
        var dummy = new ListNode();
        var cur = dummy;
        foreach (var num in nums) {
            cur.next = new ListNode(num);
            cur = cur.next;
        }
        return dummy.next!;
    }
    public int[] GetListValues(ListNode head) {
        var res = new List<int>();
        var cur = head;
        while (cur != null) {
            res.Add(cur.val);
            cur = cur.next;
        }
        return res.ToArray();
    }
}