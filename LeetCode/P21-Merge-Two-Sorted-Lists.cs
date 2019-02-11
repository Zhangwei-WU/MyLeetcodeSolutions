using LeetCode.Generics;

namespace LeetCode.P21
{
    public class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null) return null;
            var temp = new ListNode(0);
            var head = temp;

            while (true)
            {
                if (l1 == null)
                {
                    temp.next = l2;
                    break;
                }
                else if(l2 == null)
                {
                    temp.next = l1;
                    break;
                }
                else if (l1.val < l2.val)
                {
                    temp = temp.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    temp = temp.next = l2;
                    l2 = l2.next;
                }
            }

            return head.next;
        }
    }
}
