namespace LeetCode.P29
{
    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0) return int.MaxValue;
            if (divisor == 1) return dividend;
            if (divisor == -1) return dividend == int.MinValue ? int.MaxValue : -dividend;

            while ((divisor & 0x1) == 0x0)
            {
                divisor >>= 1;
                dividend >>= 1;
            }

            bool neg = false;
            if(dividend < 0)
            {
                neg = !neg;
                dividend = -dividend;
            }

            if(divisor < 0)
            {
                neg = !neg;
                divisor = -divisor;
            }
            
            if (divisor == 1) return neg ? -dividend : dividend;

            var result = 0;

            while (dividend >= divisor)
            {
                dividend -= divisor;
                result++;
            }

            return neg ? -result : result;
        }
    }
}
