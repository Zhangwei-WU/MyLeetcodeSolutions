
namespace LeetCode.P69
{
    public class Solution
    {
        // max = Math.Sqrt(int.MaxValue) + 1
        private int max = 46340 + 1;
        public int MySqrt(int x)
        {
            if (x <= 1) return x;
            int l = 1, h = System.Math.Min(x / 2 + 1, max);
            while (l < h)
            {
                var m = (l + h) / 2;
                var cp = m * m - x;
                if (cp == 0) return m;
                else if (cp > 0) h = m;
                else l = m + 1;
            }

            return l - 1;
        }
    }
}