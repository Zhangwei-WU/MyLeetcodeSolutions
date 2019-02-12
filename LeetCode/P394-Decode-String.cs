
namespace LeetCode.P394
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Solution
    {
        public string DecodeString(string s)
        {
            var ss = s.ToCharArray();
            int i = 0, l = ss.Length;
            var sb = new StringBuilder();
            foreach (var token in Decode(ss, new int[] { 0 }, l)) sb.Append(token);

            return sb.ToString();
        }

        private IEnumerable<char> Decode(char[] ss, int[] index, int length)
        {
            while (index[0] < length)
            {
                int repeat = 0;
                var c = '\0';
                while ((c = ss[index[0]++]) >= '0' && c <= '9') repeat = repeat * 10 + (c - '0');

                if (repeat != 0)
                {
                    var inner = Decode(ss, index, length).ToArray();
                    for (var j = 0; j < repeat; ++j) foreach (var w in inner) yield return w;
                }
                else
                {
                    if (c != ']') yield return c;
                    else yield break;
                }
            }
        }
    }
}
