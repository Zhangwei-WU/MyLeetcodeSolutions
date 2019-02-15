
namespace LeetCode.P28
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0;
            if (needle.Length > haystack.Length) return -1;

            var hs = haystack.ToCharArray();
            var ns = needle.ToCharArray();

            var hl = hs.Length;
            var nl = ns.Length;

            for (int i = 0, j; i <= hl - nl; ++i)
            {
                for (j = 0; j < nl; ++j)
                {
                    if (hs[i + j] != ns[j]) break;
                }

                if (j == nl) return i;
            }

            return -1;
        }
    }
}
