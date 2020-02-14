
namespace LeetCode.P131
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<IList<string>> Partition(string s)
        {
            var l = s.Length;
            var dp = new string[l, l];
            
            for (var i = 0; i < l; ++i)
            {
                for (var j = 0; i - j >= 0 && i + j < l && s[i - j] == s[i + j]; ++j)
                {
                    dp[i - j, i + j] = s.Substring(i - j, j + j + 1);
                }
                
                for (var j = 0; i - j >= 0 && i + 1 + j < l && s[i - j] == s[i + 1 + j]; ++j)
                {
                    dp[i - j, i + j + 1] = s.Substring(i - j, j + j + 2);
                }
            }
            
            return Dfs(l - 1, dp).ToArray();

        }
        
        IEnumerable<IList<string>> Dfs(int j, string[,] dp)
        {
            if (j == -1)
            {
                yield return new List<string>();
                yield break;
            }

            string c;
            for (var i = j; i >= 0; --i)
            {
                if ((c = dp[i, j]) != null)
                {
                    foreach (var result in Dfs(i - 1, dp))
                    {
                        result.Add(c);
                        yield return result;
                    }
                }
            }
        }
    }
}
