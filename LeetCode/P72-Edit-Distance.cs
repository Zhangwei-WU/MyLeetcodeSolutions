namespace LeetCode.P72
{
    using System;
    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            var m = word1.Length;
            var n = word2.Length;
            if (m == 0 || n == 0) return Math.Max(m, n);

            var c1 = word1.ToCharArray();
            var c2 = word2.ToCharArray();

            var dp = new int[n + 1];

            for (var i = 0; i <= n; i++) dp[i] = i;
            for (var i = 0; i < m; i++)
            {
                var ci = c1[i];
                for (int j = 1, a = i, b, c = i + 1; j <= n; j++)
                {
                    b = dp[j];
                    c = dp[j] = ci == c2[j - 1] ? a : Math.Min(Math.Min(a, b), c) + 1;
                    a = b;
                }
            }

            return dp[n];
        }
    }
}
