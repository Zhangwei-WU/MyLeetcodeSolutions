
namespace LeetCode.P343
{
    public class Solution
    {
        public int IntegerBreak(int n)
        {
            if (n < 4) return n - 1;

            int x = (int)System.Math.Sqrt(n), result = 0, temp;
            while ((temp = Break(n, x++)) > result) result = temp;
            return result;
        }

        private int Break(int n, int p)
        {
            var b = n / p;
            var r = n - b * p;

            var m = 1;
            for (var i = 0; i < p - r; i++) m *= b;
            for (var i = 0; i < r; i++) m *= (b + 1);
            return m;
        }
    }
}
