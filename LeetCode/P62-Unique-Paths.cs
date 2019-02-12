/* Problem 62. Unique Paths
 * https://leetcode.com/problems/unique-paths/description/
 * 
 * A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
 * The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
 * How many possible unique paths are there?
 * 
 * ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╗
 * ║ S ║   ║   ║   ║   ║   ║   ║
 * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╣
 * ║   ║   ║   ║   ║   ║   ║   ║
 * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╣
 * ║   ║   ║   ║   ║   ║   ║ F ║
 * ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╝
 * Above is a 3 x 7 grid. How many possible unique paths are there? 
 * 
 * Note: m and n will be at most 100.
 * 
 */

namespace LeetCode.P62
{
    public class Solution
    {
        private static System.Collections.Generic.Dictionary<int, int> cache = new System.Collections.Generic.Dictionary<int, int>();
        public int UniquePaths(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 || n == 1) return 1;

            var key = m < n ? (m << 8 | n) : (n << 8 | m);
            int val = 0;
            if(cache.TryGetValue(key, out val)) return val;

            val = UniquePaths(m - 1, n) + UniquePaths(m, n - 1);
            cache.TryAdd(key, val);
            return val;
        }
    }
}

namespace LeetCode.P62.S2
{
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 || n == 1) return 1;

            var dp = new int[m];
            for (var i = 0; i < m; ++i) dp[i] = 1;

            for (var i = 1; i < n; ++i)
            {
                for (var j = 1; j < m; ++j)
                {
                    dp[j] += dp[j - 1];
                }
            }

            return dp[m - 1];
        }
    }
}
