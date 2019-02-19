
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

            for (int i = 0, j, nl = ns.Length, hl = hs.Length - nl; i <= hl; ++i)
            {
                for (j = 0; j < nl; ++j) if (hs[i + j] != ns[j]) break;
                if (j == nl) return i;
            }

            return -1;
        }
    }
}
