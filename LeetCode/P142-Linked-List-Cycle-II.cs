using LeetCode.Generics;

namespace LeetCode.P142
{
    using System.Collections.Generic;

    public class Solution
    {
        public ListNode DetectCycle(ListNode head)
        {
            HashSet<ListNode> nodes = new HashSet<ListNode>();
            while (head != null)
            {
                if (!nodes.Add(head)) return head;
                head = head.next;
            }

            return null;
        }
    }
}
