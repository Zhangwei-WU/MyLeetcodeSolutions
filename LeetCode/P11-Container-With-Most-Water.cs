namespace LeetCode.P11
{
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            int len = height.Length;
            if (len <= 1) return 0;

            int l = 0, r = len - 1, max = 0, d = len;
            while (true)
            {
                var hl = height[l];
                var hr = height[r];

                var c = --d;
                if (hl < hr)
                {
                    c *= hl;
                    l++;
                }
                else
                {
                    c *= hr;
                    r--;
                }

                if (c > max) max = c;

                if (d == 1) return max;
            }
        }
    }
}
