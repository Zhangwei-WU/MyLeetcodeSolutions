
namespace LeetCode.P233
{
    public class Solution
    {
        public int CountDigitOne(int n)
        {
            if (n <= 0) return 0;

            int nn = n, b = 1;
            while ((nn /= 10) != 0) { b *= 10; }
            return F(n, b);
        }

        private int F(int n, int b)
        {
            if (b == 1) return n == 0 ? 0 : 1;
            var x = n / b;
            n -= x * b;
            b /= 10;

            var fnb = F(n, b);
            if (x == 0) return fnb;
            else if (x == 1) return F(b * 10 - 1, b) + n + 1 + fnb;
            else return x * F(b * 10 - 1, b) + b * 10 + fnb;
        }
    }
}


namespace LeetCode.P233.S2
{
    public class Solution
    {
        public int CountDigitOne(int n)
        {
            if (n <= 0) return 0;

            int b = 1, l = 1, cnt = 0;
            for (var i = n; (i /= 10) != 0; b *= 10, ++l) ;

            for (int i = l - 1; i >= 0; --i, b /= 10)
            {
                var x = n / b;
                n -= x * b;

                if (x == 0) continue;
                else if (x == 1) cnt += (b / 10 * i + n + 1);
                else cnt += b / 10 * x * i + b;
            }

            return cnt;
        }
    }
}
