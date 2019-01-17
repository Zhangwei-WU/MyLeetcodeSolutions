namespace LeetCode.P857
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public double MincostToHireWorkers(int[] quality, int[] wage, int K)
        {
            var len = quality.Length;
            if (K == 1)
            {
                var min = int.MaxValue;
                for (int i = 0; i < len; i++) if (wage[i] < min) min = wage[i];
                return min;
            }

            KeyValuePair<int, double>[] ratio = new KeyValuePair<int, double>[len];
            for (var i = 0; i < len; i++) ratio[i] = new KeyValuePair<int, double>(quality[i], wage[i] * 1.0d / quality[i]);

            Array.Sort(ratio, (a, b) => a.Value == b.Value ? 0 : a.Value < b.Value ? -1 : 1);

            var heap = new MinHeap(K);
            var totalquantity = 0;
            for (var i = 0; i < K; i++) totalquantity -= heap.Add(-ratio[i].Key);

            var minwage = totalquantity * ratio[K - 1].Value;

            for (var i = K; i < len; i++)
            {
                var kv = ratio[i];
                var cp = kv.Key + heap.Peek();
                if (cp >= 0) continue;

                heap.ReplaceMin(-kv.Key);
                var currwage = (totalquantity += cp) * kv.Value;
                if (currwage < minwage) minwage = currwage;
            }

            return minwage;
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

        public int Add(int val)
        {
            int p = ++n, n2 = 0;
            while (p > 1 && val < (n2 = array[p >> 1]))
            {
                array[p] = n2;
                p >>= 1;
            }

            array[p] = val;

            return val;
        }

        public int ReplaceMin(int val)
        {
            int p = 1, c = 2, x = n;

            int n2 = 0, min = array[1];

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
            return n == 0 ? int.MaxValue : array[1];
        }
    }

}
