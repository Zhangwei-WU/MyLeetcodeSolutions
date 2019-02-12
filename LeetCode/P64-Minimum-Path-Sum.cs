
namespace LeetCode.P64
{
    using System;

    public class Solution
    {
        public int MinPathSum(int[,] grid)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);

            var dp = new int[m];
            dp[0] = grid[0, 0];
            for (var i = 1; i < m; ++i) dp[i] = grid[i, 0] + dp[i - 1];

            for (var i = 1; i < n; ++i)
            {
                dp[0] += grid[0, i];
                for (var j = 1; j < m; ++j)
                {
                    dp[j] = Math.Min(dp[j - 1], dp[j]) + grid[j, i];
                }
            }

            return dp[m - 1];
        }
    }
}
