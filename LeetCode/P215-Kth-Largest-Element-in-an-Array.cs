
namespace LeetCode.P215
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            var minheap = new MinHeap(k);
            for (int i = 0, len = nums.Length; i < len; i++)
            {
                var ni = nums[i];
                if (i < k) minheap.Add(ni);
                else if (ni > minheap.Peek()) minheap.ReplaceMin(ni);
            }

            return minheap.Peek();
        }
    }

    public class MinHeap
    {
        public int n = 0;

        private int[] array;

        public MinHeap(int capacity)
        {
            array = new int[capacity + 1];
        }

        public bool Add(int val)
        {
            int p = ++n, n2 = 0;
            while (p > 1 && val < (n2 = array[p >> 1]))
            {
                array[p] = n2;
                p >>= 1;
            }

            array[p] = val;

            return true;
        }
        
        public void ReplaceMin(int val)
        {
            int p = 1, c = 2, x = n;
            
            int n2 = 0;

            while (c <= x)
            {
                if (c < x && array[c + 1] < array[c]) c++;
                if ((n2 = array[c]) >= val) break;

                array[p] = n2;
                p = c;
                c <<= 1;
            }

            array[p] = val;
        }

        public int Peek()
        {
            return n == 0 ? int.MaxValue : array[1];
        }
    }

}
