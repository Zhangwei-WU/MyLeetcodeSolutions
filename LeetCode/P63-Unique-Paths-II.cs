
namespace LeetCode.P63
{
    public class Solution
    {
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            var m = obstacleGrid.GetLength(0);
            var n = obstacleGrid.GetLength(1);

            if (m == 0 || n == 0) return 0;

            var dp = new int[m];
            for (var i = 0; i < m; ++i) dp[i] = obstacleGrid[i, 0] == 0 ? (i == 0 ? 1 : dp[i - 1]) : 0;

            for (var i = 1; i < n; ++i)
            {
                if (obstacleGrid[0, i] == 1) dp[0] = 0;
                for (var j = 1; j < m; ++j)
                {
                    dp[j] = obstacleGrid[j, i] == 1 ? 0 : dp[j] + dp[j - 1];
                }
            }

            return dp[m - 1];
        }
    }
}
