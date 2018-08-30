/* Problem 23: Merge k Sorted Lists
 * https://leetcode.com/problems/merge-k-sorted-lists/description/
 * 
 * Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
 * 
 * AC: 182ms
 */

namespace LeetCode.P23
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}

namespace LeetCode.P23
{
    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            MinHeap heap = new MinHeap(lists.Length);

            for (var i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null) heap.Add(lists[i]);
            }

            var root = heap.Peek();
            var curr = root;

            while (heap.Count != 0)
            {
                if (curr.next == null) heap.RemoveMin();
                else heap.ReplaceMin(curr.next);

                curr.next = heap.Peek();
                curr = curr.next;
            }

            return root;
        }
    }
    
    public class MinHeap
    {
        private ListNode[] array;
        private int n = 0;
        private int capacity = 0;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;

            array = new ListNode[this.capacity + 1];
        }

        public bool Add(ListNode node)
        {
            var p = ++n;
            if (p > capacity) return false;

            while (p > 1 && node.val < array[p >> 1].val)
            {
                array[p] = array[p >> 1];
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
            
            while (c <= x)
            {
                if (c < x && array[c+1].val < array[c].val) c++;
                if (array[c].val >= val) break;

                array[p] = array[c];
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

            while (c <= x)
            {
                if (c < x && array[c + 1].val < array[c].val) c++;
                if (array[c].val >= node.val) break;

                array[p] = array[c];
                p = c;
                c <<= 1;
            }

            array[p] = node;
        }

        public ListNode Peek()
        {
            return n == 0 ? null : array[1];
        }

        public void Clear()
        {
            n = 0;
        }

        public int Count
        {
            get
            {
                return n;
            }
        }
    }

}
