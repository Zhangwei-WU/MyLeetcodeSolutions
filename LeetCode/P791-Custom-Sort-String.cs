
namespace LeetCode.P791
{
    using System;

    public class Solution
    {
        public string CustomSortString(string S, string T)
        {
            var tbl = new int[26];
            var sarr = S.ToCharArray();
            var tarr = T.ToCharArray();
            for (var i = 0; i < sarr.Length; ++i) tbl[sarr[i] - 'a'] = i + 1;
            Array.Sort(tarr, (a, b) => tbl[a - 'a'] - tbl[b - 'a']);
            return new string(tarr);
        }
    }
}
