using LeetCode.Generics;

namespace LeetCode.P725
{
    public class Solution
    {
        public ListNode[] SplitListToParts(ListNode root, int k)
        {
            var iter = root;
            var l = 0;
            while (iter != null) { iter = iter.next; ++l; }

            var result = new ListNode[k];
            iter = root;
            for (int i = 0, p = l / k, r = l % k; i < k; ++i)
            {
                result[i] = iter;
                var s = i < r ? p + 1 : p;
                if (s == 0) break;
                for (var j = 0; j < s - 1; ++j) iter = iter.next;

                var t = iter.next;
                iter.next = null;
                iter = t;
            }

            return result;
        }
    }
}
