
namespace LeetCode.P378
{
    using System;

    public class Solution
    {
        public int KthSmallest(int[,] matrix, int k)
        {
            var heap = new Heap<int>(k, (a, b) => b - a);

            var n = matrix.GetLength(0);

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var v = matrix[i, j];
                    if (heap.N < k) heap.Add(v);
                    else if (heap.Peek() > v) heap.Replace(v);
                    else break;
                }
            }

            return heap.Peek();
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

            public T Remove()
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

            public T Replace(T node)
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
