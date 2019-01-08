namespace LeetCode.P206
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode ReverseList(ListNode head)
        {

            var curr = head;
            var prev = default(ListNode);
            while (curr != null)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }
    }
}
