namespace LeetCode.P25
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            throw new NotImplementedException();
            if (k < 2 || head == null) return head;

            var superNode = new ListNode(0);
            superNode.next = head;

            var p = superNode;
            var end = default(ListNode);
            for (var i = 0; i < k; i++)
            {
                if (p == null) break;
                p = p.next;
            }


            return superNode.next;
        }
    }
}
