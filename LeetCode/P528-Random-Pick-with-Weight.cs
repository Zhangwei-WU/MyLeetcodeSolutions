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
            var next = rnd.Next(total) + 1;
            var idx = Array.BinarySearch(numbers, next);
            if (idx < 0) idx = ~idx;
            return idx;
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(w);
     * int param_1 = obj.PickIndex();
     */
}
