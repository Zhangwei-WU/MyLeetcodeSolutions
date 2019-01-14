namespace LeetCode.P239
{
    using System.Collections.Generic;

    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var len = nums.Length;
            if (len == 0) return new int[0];
            var result = new int[len - k + 1];

            MinHeap window = new MinHeap(len);

            for (var i = 0; i < k - 1; i++) window.Add(i, -nums[i]);

            for (int i = k - 1, j = 0; i < len; i++, j++)
            {
                while (window.n != 0 && window.Peek().Key < j) window.RemoveMin();

                window.Add(i, -nums[i]);
                result[j] = -window.Peek().Value;
            }

            return result;
        }
    }

    public class MinHeap
    {
        public int n = 0;

        private KeyValuePair<int, int>[] array;

        public MinHeap(int capacity)
        {
            array = new KeyValuePair<int, int>[capacity + 1];
        }

        public bool Add(int key, int val)
        {
            int p = ++n;
            KeyValuePair<int, int> n2;
            while (p > 1 && val < (n2 = array[p >> 1]).Value)
            {
                array[p] = n2;
                p >>= 1;
            }

            array[p] = new KeyValuePair<int, int>(key, val);

            return true;
        }
        
        public KeyValuePair<int, int> RemoveMin()
        {
            int p = 1, c = 2, x = n - 1;
            KeyValuePair<int, int> val = array[n], e = array[p], n2;

            while (c <= x)
            {
                if (c < x && array[c + 1].Value < array[c].Value) c++;
                if ((n2 = array[c]).Value >= val.Value) break;

                array[p] = n2;
                p = c;
                c <<= 1;
            }

            array[p] = array[x + 1];
            n--;

            return e;
        }

        public KeyValuePair<int, int> Peek()
        {
            return array[1];
        }
    }

}
