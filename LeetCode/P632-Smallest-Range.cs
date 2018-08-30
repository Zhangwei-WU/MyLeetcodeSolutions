/* Problem 632. Smallest Range
 * https://leetcode.com/problems/smallest-range/description/
 * 
 * You have k lists of sorted integers in ascending order. Find the smallest range that includes at least one number from each of the k lists.
 * We define the range [a,b] is smaller than range [c,d] if b-a < d-c or a < c if b-a == d-c.
 * 
 * Example 1:
 * Input:[[4,10,15,24,26], [0,9,12,20], [5,18,22,30]]
 * Output: [20,24]
 * Explanation: 
 * List 1: [4, 10, 15, 24,26], 24 is in range [20,24].
 * List 2: [0, 9, 12, 20], 20 is in range [20,24].
 * List 3: [5, 18, 22, 30], 22 is in range [20,24].
 * 
 * Note:
 * The given list may contain duplicates, so ascending order means >= here.
 * 1 <= k <= 3500
 * -10^5 <= value of elements <= 10^5.
 * 
 */
namespace LeetCode.P632
{
    using System.Collections.Generic;

    public class Solution
    {
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            var len = nums.Count;
            var lens = new int[len];
            var poss = new int[len];
            var head = new MinHeap(len);

            int min = -100001, max = 100001, tempmax = min;
            for (var i = 0; i < len; i++)
            {
                lens[i] = nums[i].Count;
                var val = nums[i][poss[i]++];
                head.Add(val, i);
                if (val > tempmax) tempmax = val;
            }

            while (true)
            {
                var peek = head.Peek();
                var gap = tempmax - peek.Key;
                if (gap < max - min)
                {
                    min = peek.Key;
                    max = tempmax;
                }
                if (gap == 0) return new int[] { min, max };

                var i = peek.Value;
                var num = nums[i];
                var pos = poss[i];
                if (pos == lens[i]) return new int[] { min, max };
                while (pos != lens[i] - 1 && num[pos] == num[pos + 1]) pos++;
                var val = num[pos];
                poss[i] = pos + 1;
                head.ReplaceMin(val, i);
                if (val > tempmax) tempmax = val;
            }
        }
    }

    public class MinHeap
    {
        public struct KV { public int Key; public int Value; }

        private KV[] array;
        private int n = 0;
        private int capacity = 0;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            array = new KV[this.capacity + 1];
        }

        public bool Add(int key, int val)
        {
            var p = ++n;
            if (p > capacity) return false;

            while (p > 1 && key < array[p >> 1].Key)
            {
                array[p] = array[p >> 1];
                p >>= 1;
            }

            array[p].Key = key;
            array[p].Value = val;

            return true;
        }
        public KV RemoveMin()
        {
            int p = 1, c = 2, x = n - 1;
            int val = array[n].Key;
            KV e = array[p];

            while (c <= x)
            {
                if (c < x && array[c + 1].Key < array[c].Key) c++;
                if (array[c].Key >= val) break;

                array[p] = array[c];
                p = c;
                c <<= 1;
            }

            array[p] = array[x + 1];
            n--;

            return e;

        }
        public void ReplaceMin(int key, int val)
        {
            int p = 1, c = 2, x = n;

            while (c <= x)
            {
                if (c < x && array[c + 1].Key < array[c].Key) c++;
                if (array[c].Key >= key) break;

                array[p] = array[c];
                p = c;
                c <<= 1;
            }

            array[p].Key = key;
            array[p].Value = val;
        }

        public KV Peek() { return n == 0 ? default(KV) : array[1]; }
        public void Clear() { n = 0; }
        public int Count { get { return n; } }
    }

}
