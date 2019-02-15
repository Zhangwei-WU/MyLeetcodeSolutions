
using LeetCode.Generics;

namespace LeetCode.P92
{
    public class Solution
    {
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (m == n) return head;

            var superNode = new ListNode(0) { next = head };

            var p = superNode;
            for (var i = 1; i < m; ++i) p = p.next;
            var q = p;
            for (var i = 0; i <= n - m; ++i) q = q.next;

            var r = p.next;
            p.next = q;
            var s = r.next;
            r.next = q.next;
            while (r != q)
            {
                var t = s.next;
                s.next = r;
                r = s;
                s = t;
            }

            return superNode.next;
        }
    }
}
