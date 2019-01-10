
namespace LeetCode.P49
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();
            for (int i = 0, len = strs.Length; i < len; i++)
            {
                var s = strs[i];
                var c = s.ToCharArray();
                Array.Sort(c);
                var ns = new string(c);
                if(!dict.TryGetValue(ns, out IList<string> value))
                {
                    value = new List<string>();
                    value.Add(s);
                    dict.Add(ns, value);
                }
                else
                {
                    value.Add(s);
                }
            }

            var output = new IList<string>[dict.Count];
            dict.Values.CopyTo(output, 0);
            return output;
        }
    }
}
