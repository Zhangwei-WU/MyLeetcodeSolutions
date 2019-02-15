
using LeetCode.Generics;

namespace LeetCode.P148
{
    using System.Collections.Generic;

    public class Solution
    {
        public ListNode SortList(ListNode head)
        {
            ListNode p = null;
            foreach(var node in Sort(head))
            {
                if(p == null) head = p = node;
                else p = p.next = node;
            }

            if (p != null) p.next = null;
            return head;
        }

        public IEnumerable<ListNode> Sort(ListNode head)
        {
            if (head == null) yield break;

            var returned = false;
            foreach (var r in Sort(head.next))
            {
                if (!returned && r.val >= head.val)
                {
                    yield return head;
                    returned = true;
                }

                yield return r;
            }

            if (!returned) yield return head;
        }
    }
}
