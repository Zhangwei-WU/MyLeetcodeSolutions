namespace LeetCode.P528
{
    using System;
    public class Solution
    {
        private int[] numbers = null;
        private int total = 0;
        private Random rnd = new Random();
        public Solution(int[] w)
        {
            numbers = new int[w.Length];
            for (var i = 0; i < w.Length; i++)
            {
                total += w[i];
                numbers[i] = total;
            }
        }

        public int PickIndex()
        {
            var idx = Array.BinarySearch(numbers, rnd.Next(total) + 1);
            return idx < 0 ? ~idx : idx;
        }
    }
}
