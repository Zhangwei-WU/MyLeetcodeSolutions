
namespace LeetCode.P131
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<IList<string>> Partition(string s)
        {
            var chs = s.ToCharArray();
            var l = chs.Length;
            var dp = new int[l, l];
            
            return Dfs(chs, l - 1, dp).ToArray();
        }

        private int Fill(char[] chs, int i, int j, int[,] dp)
        {
            if (i >= j) return 1;
            if (dp[i, j] != 0) return dp[i, j];
            if (chs[i] == chs[j]) return dp[i, j] = Fill(chs, i + 1, j - 1, dp);
            return dp[i, j] = -1;
        }

        IEnumerable<IList<string>> Dfs(char[] chs, int j, int[,] dp)
        {
            if (j == -1)
            {
                yield return new List<string>();
                yield break;
            }

            for (var i = j; i >= 0; --i)
            {
                if (i == j || Fill(chs, i, j, dp) == 1)
                {
                    var str = new string(chs, i, j - i + 1);
                    foreach (var result in Dfs(chs, i - 1, dp))
                    {
                        result.Add(str);
                        yield return result;
                    }
                }
            }
        }
    }
}
