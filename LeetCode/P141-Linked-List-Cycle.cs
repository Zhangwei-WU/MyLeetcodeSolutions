using LeetCode.Generics;

namespace LeetCode.P141
{
    using System.Collections.Generic;
    
    public class Solution
    {
        public bool HasCycle(ListNode head)
        {
            HashSet<ListNode> nodes = new HashSet<ListNode>();
            while (head != null)
            {
                if (!nodes.Add(head)) return true;
                head = head.next;
            }

            return false;
        }
    }
}
