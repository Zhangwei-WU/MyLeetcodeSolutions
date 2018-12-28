namespace LeetCode.P5
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            var cs = s.ToCharArray();

            var lcs = LCS(cs, cs.Reverse().ToArray(), cs.Length, 0, 0);

            return s.Substring(lcs.Key, lcs.Value);
        }

        // <pos, len>
        public KeyValuePair<int, int> LCS(char[] s1, char[] s2, int l, int i, int j)
        {
            if (i == l || j == l) return new KeyValuePair<int, int>(i, 0);
            if (s1[i] == s2[j])
            {
                var lcs = LCS(s1, s2, l, i + 1, j + 1);
                if (lcs.Key == i + 1) return new KeyValuePair<int, int>(i, lcs.Value + 1);
                else if (lcs.Value > 1) return lcs;
                else return new KeyValuePair<int, int>(i, 1);
            }

            var lcs1 = LCS(s1, s2, l, i + 1, j);
            var lcs2 = LCS(s1, s2, l, i, j + 1);

            if (lcs1.Value == lcs2.Value) return lcs1.Key < lcs2.Key ? lcs1 : lcs2;
            return lcs1.Value > lcs2.Value ? lcs1 : lcs2;
        }
    }
}
