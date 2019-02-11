
namespace LeetCode.P279
{
    using System;

    public class Solution
    {
        public int NumSquares(int n)
        {
            var dp = new int[n + 1];
            for (var i = 1; i <= n; i++)
            {
                dp[i] = int.MaxValue;
                for (int j = 1, s; (s = j * j) <= i; ++j)
                {
                    dp[i] = Math.Min(dp[i], dp[i - s] + 1);
                }
            }

            return dp[n];
        }

    }
}
