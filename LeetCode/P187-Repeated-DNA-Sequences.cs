
namespace LeetCode.P187
{
    using System.Collections.Generic;

    public class Solution
    {
        private const int LENGTH = 10;

        private class DNA
        {
            public DNA() { Next = new DNA[4]; }
            public DNA[] Next;
            public int Count;
        }

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            var root = new DNA();
            var repeats = new DNA[LENGTH];

            var output = new List<string>();
            for (int i = 0, j = 0, len = s.Length; i <= len; ++i, ++j)
            {
                if (j == LENGTH) j = 0;
                if (repeats[j] != null && repeats[j].Count++ == 1)
                {
                    output.Add(s.Substring(i - LENGTH, LENGTH));
                }

                if (i == len) break;
                repeats[j] = root;

                var c = s[i];
                var index = c == 'A' ? 0 : c == 'C' ? 1 : c == 'G' ? 2 : 3;
                for (var k = 0; k < LENGTH; ++k)
                {
                    var rk = repeats[k];
                    if (rk == null) break;
                    if (rk.Next[index] == null) rk.Next[index] = new DNA();
                    repeats[k] = rk.Next[index];
                }
            }
            
            return output;
        }
    }
}
