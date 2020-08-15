
using System;
using System.Collections.Generic;

namespace LeetCode.P398
{
    public class Solution
    {
        KeyValuePair<int,int>[] arr;
        Random rnd;
        public Solution(int[] nums)
        {
            arr = new KeyValuePair<int, int>[nums.Length];
            for (var i = 0; i < nums.Length; ++i)
            {
                arr[i] = new KeyValuePair<int, int>(nums[i], i);
            }
            Array.Sort(arr, (a, b) => a.Key - b.Key);

            rnd = new Random();
        }

        public int Pick(int target)
        {
            var l = BinarySearchL(arr, 0, arr.Length, target);
            var h = BinarySearchR(arr, 0, arr.Length, target);

            if (l == h) return arr[l].Value;
            return arr[l + rnd.Next(h - l + 1)].Value;
        }


        private int BinarySearchL(KeyValuePair<int, int>[] array, int index, int length, int value)
        {
            int lo = index;
            int hi = index + length - 1;
            while (lo <= hi)
            {
                int i = lo + ((hi - lo) >> 1);
                int o1 = array[i].Key - value;
                var o2 = i == 0 ? -1 : (array[i - 1].Key - value);

                if (o1 == 0 && o2 < 0) return i;

                if (o1 < 0) lo = i + 1;
                else hi = i - 1;
            }

            return ~lo;
        }

        private int BinarySearchR(KeyValuePair<int, int>[] array, int index, int length, int value)
        {
            int lo = index;
            int hi = index + length - 1;
            while (lo <= hi)
            {
                int i = lo + ((hi - lo) >> 1);
                int o1 = array[i].Key - value;
                var o2 = i == index + length - 1 ? 1 : (array[i + 1].Key - value);

                if (o1 == 0 && o2 > 0) return i;

                if (o1 <= 0) lo = i + 1;
                else hi = i - 1;
            }

            return ~lo;
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(nums);
     * int param_1 = obj.Pick(target);
     */
}

namespace LeetCode.P398.S2
{
    public class Solution
    {
        Dictionary<int, List<int>> idx = new Dictionary<int, List<int>>();
        Random rnd;
        public Solution(int[] nums)
        {
            for (var i = 0; i < nums.Length; ++i)
            {
                var n = nums[i];
                if (!idx.TryGetValue(n, out List<int> p))
                {
                    idx.Add(n, p = new List<int>());
                }

                p.Add(i);
            }

            rnd = new Random();
        }

        public int Pick(int target)
        {
            var pos = idx[target];
            if (pos.Count == 1) return pos[0];
            return pos[rnd.Next(pos.Count)];
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(nums);
     * int param_1 = obj.Pick(target);
     */
}
