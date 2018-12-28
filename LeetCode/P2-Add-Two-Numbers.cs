using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.P2
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var head = new ListNode(0) { next = new ListNode(0) };
            var p = head;
            var p1 = l1;
            var p2 = l2;

            while (true)
            {
                if (p1 == null && p2 == null) break;

                p = p.next;

                if (p1 != null) { p.val += p1.val; p1 = p1.next; }
                if (p2 != null) { p.val += p2.val; p2 = p2.next; }

                p.next = new ListNode(0);
                if (p.val >= 10) { p.val -= 10; p.next.val++; }
            }

            if (p.next != null && p.next.val == 0) p.next = null;
            return head.next;
        }
    }
}
