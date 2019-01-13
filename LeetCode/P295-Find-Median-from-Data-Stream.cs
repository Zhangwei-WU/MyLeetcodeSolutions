namespace LeetCode.P295
{
    using System.Collections.Generic;

    public class MedianFinder
    {
        private MinHeap lowerHeap;
        private MinHeap upperHeap;
        /** initialize your data structure here. */
        public MedianFinder()
        {
            lowerHeap = new MinHeap();
            lowerHeap.Add(int.MaxValue);
            upperHeap = new MinHeap();
            upperHeap.Add(int.MaxValue);
        }

        public void AddNum(int num)
        {
            if (lowerHeap.n == upperHeap.n)
            {
                if (num <= -lowerHeap.Peek()) upperHeap.Add(-lowerHeap.ReplaceMin(-num));
                else upperHeap.Add(num);
            }
            else
            {
                if (num >= upperHeap.Peek()) lowerHeap.Add(-upperHeap.ReplaceMin(num));
                else lowerHeap.Add(-num);
            }
        }

        public double FindMedian()
        {
            return lowerHeap.n == upperHeap.n
                ? (-lowerHeap.Peek() + upperHeap.Peek()) / 2.0d
                : upperHeap.Peek();
        }
    }

    public class MinHeap
    {
        public int n = 0;

        private List<int> array;

        public MinHeap()
        {
            array = new List<int>();
            array.Add(0);
        }

        public bool Add(int val)
        {
            array.Add(val);
            int p = ++n, n2 = 0;
            while (p > 1 && val < (n2 = array[p >> 1]))
            {
                array[p] = n2;
                p >>= 1;
            }

            array[p] = val;

            return true;
        }

        public int ReplaceMin(int val)
        {
            int p = 1, c = 2, x = n;
            int min = array[p];
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
            return min;
        }

        public int Peek()
        {
            return n == 0 ? int.MinValue : array[1];
        }
    }
}
