
namespace LeetCode.P14
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return string.Empty;
            if (strs.Length == 1) return strs[0];

            var idx = -1;
            var baseline = strs[0];

            while (true)
            {
                var broken = baseline.Length <= ++idx;
                if (broken) break;

                var chr = baseline[idx];

                for (var i = 1; i < strs.Length; i++)
                {
                    if (strs[i].Length <= idx || strs[i][idx] != chr)
                    {
                        broken = true;
                        break;
                    }
                }

                if (broken) break;
            }

            return baseline.Substring(0, idx);
        }
    }
}
