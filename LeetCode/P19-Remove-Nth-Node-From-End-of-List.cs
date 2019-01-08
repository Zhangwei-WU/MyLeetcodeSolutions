namespace LeetCode.P19
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var superhead = new ListNode(0) { next = head };
            var p = superhead;

            var index = 0;
            while (head != null)
            {
                if (index < n) index++;
                else p = p.next;
                head = head.next;
            }
            
            p.next = p.next.next;

            return superhead.next;
        }
    }
}
