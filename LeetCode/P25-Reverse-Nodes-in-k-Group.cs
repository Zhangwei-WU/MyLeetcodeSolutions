namespace LeetCode.P25
{
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
            if (k == 1 || head == null || head.next == null) return head;

            var superNode = new ListNode(0);
            superNode.next = head;

            ListNode start = superNode, end = start;
            bool reverse = true;

            while (reverse)
            {
                for (var i = 0; i < k; i++)
                {
                    end = end.next;
                    if (end == null)
                    {
                        reverse = false;
                        break;
                    }
                }

                if (reverse)
                {
                    var curr = start.next;
                    start.next = end;
                    start = curr.next;
                    curr.next = end.next;
                    var nextstart = curr;

                    while (true)
                    {
                        var next = start.next;
                        start.next = curr;
                        if (start == end) break;
                        curr = start;
                        start = next;
                    }

                    start = end = nextstart;
                }
            }

            return superNode.next;
        }
    }
}
