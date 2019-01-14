namespace LeetCode.P331
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var result = new List<IList<int>>();

            var len = words.Length;
            var maxlen = 0;
            for (var i = 0; i < len; i++) if (words[i].Length > maxlen) maxlen = words[i].Length;
            char[] cache = new char[maxlen * 2];
            for (var i = 0; i < len; i++)
            {
                var wi = words[i];
                var li = wi.Length;
                Array.Copy(wi.ToCharArray(), cache, li);
                for (var j = 0; j < len; j++)
                {
                    if (i == j) continue;
                    var wj = words[j];
                    var lj = wj.Length;
                    Array.Copy(wj.ToCharArray(), 0, cache, li, lj);
                    var totalLength = li + lj;
                    bool add = true;
                    for (var k = 0; k < totalLength / 2; k++)
                    {
                        if (cache[k] != cache[totalLength - 1 - k])
                        {
                            add = false;
                            break;
                        }
                    }

                    if (add) result.Add(new int[] { i, j });
                }
            }

            return result;
        }
    }
}
