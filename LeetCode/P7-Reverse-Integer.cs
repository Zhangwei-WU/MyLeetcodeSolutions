
namespace LeetCode
{
    public class Solution
    {
        public int Reverse(int x)
        {
            if (x == int.MinValue) return 0;
            bool isNeg = x < 0;
            if (isNeg) x = -x;
            var nomorethan = int.MaxValue / 10 + 1;
            var y = 0;
            while (x != 0)
            {
                if (y >= nomorethan) return 0;
                y *= 10;
                y += (x % 10);
                x /= 10;
            }

            if (isNeg) y *= -1;
            return y;
        }
    }
}
