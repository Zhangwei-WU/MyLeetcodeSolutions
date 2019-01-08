namespace LeetCode.P29
{
    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0) return int.MaxValue;
            if (dividend == 0) return 0;
            if (divisor == 1) return dividend;
            if (divisor == -1) return dividend == int.MinValue ? int.MaxValue : -dividend;

            long ldividend = dividend, ldivisor = divisor;

            bool neg = false;
            if(ldividend < 0) { neg = !neg; ldividend = -ldividend; }
            if(ldivisor < 0) { neg = !neg; ldivisor = -ldivisor; }
            if (ldividend < ldivisor) return 0;

            var result = 0;

            while (ldividend >= ldivisor)
            {
                var subresult = 0;
                while (ldividend >= (ldivisor << ++subresult)) ;
                result += (1 << --subresult);
                ldividend -= (ldivisor << subresult);
            }

            return neg ? -result : result;
        }
    }
}
