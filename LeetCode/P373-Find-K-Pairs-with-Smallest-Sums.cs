namespace LeetCode.P373
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            if (k == 0) return new int[0][];
            var heap = new Heap<KeyValuePair<int, int>>(k, (a, b) => b.Value - a.Value);

            for (int i = 0, l1 = nums1.Length; i < l1; i++)
            {
                var ni = nums1[i];
                for (int j = 0, l2 = nums2.Length; j < l2; j++)
                {
                    var sum = ni + nums2[j];
                    if (heap.N < k) heap.Add(new KeyValuePair<int, int>(ni, sum));
                    else if (heap.Peek().Value > sum) heap.ReplaceMin(new KeyValuePair<int, int>(ni, sum));
                    else break;
                }
            }

            var result = new int[heap.N][];
            for (var i = heap.N - 1; i >= 0; i--)
            {
                var peek = heap.RemoveMin();
                result[i] = new int[] { peek.Key, peek.Value - peek.Key };
            }

            return result;
        }

        public class Heap<T>
        {
            public int N { get { return n; } }
            public int Capacity { get { return capacity; } }

            private int n = 0;
            private int capacity = 0;
            private T[] array;
            private Comparison<T> cp;

            public Heap(int capacity, Comparison<T> comparison)
            {
                if (capacity <= 0) throw new ArgumentOutOfRangeException("capacity");
                if (comparison == null) throw new ArgumentNullException("comparison");

                this.capacity = capacity;
                this.cp = comparison;
                array = new T[capacity + 1];
            }

            public bool Add(T node)
            {
                if (n == capacity) return false;

                int p = ++n;

                T n2 = default(T);
                while (p > 1 && cp(node, n2 = array[p >> 1]) < 0)
                {
                    array[p] = n2;
                    p >>= 1;
                }

                array[p] = node;
                return true;
            }

            public T RemoveMin()
            {
                if (n == 0) return default(T);

                int p = 1, c = 2;
                T e = array[p], n2 = default(T);

                while (c < n)
                {
                    if (c < n - 1 && cp(array[c + 1], array[c]) < 0) ++c;
                    if (cp(n2 = array[c], array[n]) >= 0) break;

                    array[p] = n2;
                    p = c;
                    c <<= 1;
                }

                array[p] = array[n--];
                return e;
            }

            public T ReplaceMin(T node)
            {
                if (n == 0)
                {
                    Add(node);
                    return default(T);
                }

                int p = 1, c = 2;
                T e = array[p], n2 = default(T);

                while (c <= n)
                {
                    if (c < n && cp(array[c + 1], array[c]) < 0) ++c;
                    if (cp(n2 = array[c], node) >= 0) break;

                    array[p] = n2;
                    p = c;
                    c <<= 1;
                }

                array[p] = node;
                return e;
            }

            public T Peek()
            {
                return n == 0 ? default(T) : array[1];
            }

            public void Clear()
            {
                n = 0;
            }
        }

    }
}
