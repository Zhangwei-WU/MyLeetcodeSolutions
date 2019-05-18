
namespace LeetCode.P131
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<string>> Partition(string s)
        {
            var chs = s.ToCharArray();
            var l = chs.Length;
            var dp = new int[l, l];

            for (var i = 0; i < l; ++i)
            {
                for (var j = i; j < l; ++j)
                {
                    Fill(chs, i, j, dp);
                }
            }

            return new List<IList<string>>(Dfs(chs, l - 1, dp));
        }

        private int Fill(char[] chs, int i, int j, int[,] dp)
        {
            if (dp[i, j] != 0) return dp[i, j];
            if (i > j) return 1;
            if (i == j) return dp[i, j] = 1;
            if (chs[i] == chs[j]) return dp[i, j] = Fill(chs, i + 1, j - 1, dp);
            return dp[i, j] = -1;
        }

        IEnumerable<IList<string>> Dfs(char[] chs, int i, int[,] dp)
        {
            if (i == -1)
            {
                yield return new List<string>();
                yield break;
            }

            for (var j = i; j >= 0; --j)
            {
                if (dp[j, i] == 1)
                {
                    var str = new string(chs, j, i - j + 1);
                    foreach (var result in Dfs(chs, j - 1, dp))
                    {
                        result.Add(str);
                        yield return result;
                    }
                }
            }
        }
    }
}
