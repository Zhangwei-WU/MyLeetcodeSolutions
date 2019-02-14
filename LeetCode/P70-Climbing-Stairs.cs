
namespace LeetCode.P70
{
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            if (n == 0 || n == 1) return 1;

            var v1 = 1;
            var v2 = 1;
            for (var i = 2; i <= n; i++)
            {
                var v3 = v1 + v2;
                v1 = v2;
                v2 = v3;
            }

            return v2;
        }
    }
}
