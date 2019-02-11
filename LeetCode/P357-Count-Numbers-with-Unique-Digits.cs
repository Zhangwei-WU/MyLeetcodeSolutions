
namespace LeetCode.P357
{
    public class Solution
    {
        public int CountNumbersWithUniqueDigits(int n)
        {
            if (n > 10) n = 10;

            var cnt = 1;
            for (var i = 1; i <= n; ++i)
            {
                var c = 9;
                for (var j = 1; j < i; ++j) c *= (10 - j);
                cnt += c;
            }

            return cnt;
        }
    }
}
