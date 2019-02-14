/* Problem 23: Merge k Sorted Lists
 * https://leetcode.com/problems/merge-k-sorted-lists/description/
 * 
 * Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
 * 
 * AC: 182ms
 */

using LeetCode.Generics;

namespace LeetCode.P23
{
    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            MinHeap heap = new MinHeap(lists.Length);

            for (var i = 0; i < lists.Length; i++) if (lists[i] != null) heap.Add(lists[i]);

            var root = heap.Peek();
            for(var curr = root; heap.n != 0; curr = curr.next)
            {
                if (curr.next == null) heap.RemoveMin();
                else heap.ReplaceMin(curr.next);

                curr.next = heap.Peek();
            }

            return root;
        }
    }

    public class MinHeap
    {
        public int n = 0;

        private ListNode[] array;

        public MinHeap(int capacity)
        {
            array = new ListNode[capacity + 1];
        }

        public bool Add(ListNode node)
        {
            var p = ++n;

            var val = node.val;
            ListNode n2 = null;
            while (p > 1 && val < (n2 = array[p >> 1]).val)
            {
                array[p] = n2;
                p >>= 1;
            }

            array[p] = node;

            return true;
        }

        public ListNode RemoveMin()
        {
            int p = 1, c = 2, x = n - 1;
            int val = array[n].val;
            ListNode e = array[p];
            ListNode n2 = null;

            while (c <= x)
            {
                if (c < x && array[c + 1].val < array[c].val) c++;
                if ((n2 = array[c]).val >= val) break;

                array[p] = n2;
                p = c;
                c <<= 1;
            }

            array[p] = array[x + 1];
            n--;

            return e;
        }

        public void ReplaceMin(ListNode node)
        {
            int p = 1, c = 2, x = n;

            var val = node.val;
            ListNode n2 = null;

            while (c <= x)
            {
                if (c < x && array[c + 1].val < array[c].val) c++;
                if ((n2 = array[c]).val >= val) break;

                array[p] = n2;
                p = c;
                c <<= 1;
            }

            array[p] = node;
        }

        public ListNode Peek()
        {
            return n == 0 ? null : array[1];
        }
    }
}

namespace LeetCode.P23.S2
{
    using System.Collections.Generic;

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;
            if (lists.Length == 1) return lists[0];
            if (lists.Length == 2) return MergeTwoLists(lists[0], lists[1]);

            var result = new List<ListNode>(lists);
            var len = 0;
            while ((len = result.Count) != 1)
            {
                var newResult = new List<ListNode>((len + 1) / 2);
                for (var i = 0; i < len; i += 2)
                {
                    if (i == len - 1) newResult.Add(result[i]);
                    else newResult.Add(MergeTwoLists(result[i], result[i + 1]));
                }

                result = newResult;
            }

            return result[0];
        }

        private ListNode MergeTwoLists(ListNode l1, ListNode l2)
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
                else if (l2 == null)
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