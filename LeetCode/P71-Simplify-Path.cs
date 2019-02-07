
namespace LeetCode.P71
{
    public class Solution
    {
        public string SimplifyPath(string path)
        {
            var paths = path.Split('/');
            var clen = 0;
            for (int i = 1, len = paths.Length; i < len; i++)
            {
                var c = paths[i];
                if (string.IsNullOrEmpty(c) || c == ".") continue;
                else if (c == "..")
                {
                    if(clen > 0) clen--;
                }
                else paths[clen++] = c;
            }

            return "/" + string.Join('/', paths, 0, clen);
        }
    }
}
