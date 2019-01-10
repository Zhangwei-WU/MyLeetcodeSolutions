namespace LeetCode.P93
{
    using System.Collections.Generic;
    using System.Linq;
    public class Solution
    {
        public IList<string> RestoreIpAddresses(string s)
        {
            return Dfs(s.ToCharArray(), 0, s.Length, 0).Distinct().ToArray();
        }

        private IEnumerable<string> Dfs(char[] chars, int index, int length, int depth)
        {
            // last part
            if (depth == 3)
            {
                if (index == length || index < length - 3) yield break;
                else if (index == length - 1) yield return new string(chars, index, 1);
                else if (chars[index] != '0' && (index >= length - 2 || 
                    (chars[index] < '2'
                    || chars[index] == '2' && chars[index + 1] < '5'
                    || chars[index] == '2' && chars[index + 1] == '5' && chars[index + 2] <= '5')))
                {
                    yield return new string(chars, index, length - index);
                }
                else yield break;
            }
            else
            {
                if (index == length) yield break;
                // try take 1
                var part = new string(chars, index, 1);
                foreach (var result in Dfs(chars, index + 1, length, depth + 1)) yield return part + "." + result;
                if (chars[index] == '0') yield break;
                // try take 2
                if (index >= length - 1) yield break;
                part = new string(chars, index, 2);
                foreach (var result in Dfs(chars, index + 2, length, depth + 1)) yield return part + "." + result;
                if (index >= length - 2) yield break;
                // try take 3
                if (chars[index] < '2'
                    || chars[index] == '2' && chars[index + 1] < '5'
                    || chars[index] == '2' && chars[index + 1] == '5' && chars[index + 2] <= '5')
                {
                    part = new string(chars, index, 3);
                    foreach (var result in Dfs(chars, index + 3, length, depth + 1)) yield return part + "." + result;
                }
            }
        }
    }
}
