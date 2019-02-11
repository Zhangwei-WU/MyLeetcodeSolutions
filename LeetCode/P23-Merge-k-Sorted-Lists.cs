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
