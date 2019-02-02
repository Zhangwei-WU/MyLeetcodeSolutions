
namespace LeetCode.P218
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<int[]> GetSkyline(int[,] buildings)
        {
            var n = buildings.GetLength(0);
            var hei = new Tuple<int, int, int>[n << 1];

            for (var i = 0; i < n; i++)
            {
                var l = buildings[i, 0];
                var r = buildings[i, 1];
                var h = buildings[i, 2];

                hei[i << 1] = new Tuple<int, int, int>(l, 0, h);
                hei[(i << 1) + 1] = new Tuple<int, int, int>(r, 1, h);
            }
            
            Array.Sort(hei, (a, b) =>
            {
                var cp = a.Item1 - b.Item1;
                if (cp != 0) return cp;
                cp = a.Item2 - b.Item2;
                if (cp != 0) return cp;
                return b.Item3 - a.Item3;
            });
            
            var result = new List<int[]>();
            if (n != 0)
            {
                var start = new Heap<int>(n, (a, b) => b - a);
                var end = new Heap<int>(n, (a, b) => b - a);

                n <<= 1;

                var index = hei[0].Item1;
                start.Add(hei[0].Item3);
                var height = -1;
                for (var i = 1; i < n; i++)
                {
                    var c = hei[i];

                    if (c.Item1 != index)
                    {
                        var nheight = start.Peek();
                        if (height != nheight) result.Add(new int[] { index, height = nheight });
                        index = c.Item1;
                    }

                    var cheight = c.Item3;
                    if (c.Item2 == 0) start.Add(cheight);
                    else if (start.Peek() == cheight)
                    {
                        start.RemoveMin();
                        while (start.N != 0 && start.Peek() == end.Peek())
                        {
                            start.RemoveMin();
                            end.RemoveMin();
                        }
                    }
                    else end.Add(cheight);
                }

                result.Add(new int[] { index, 0 });
            }

            return result;
        }
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
