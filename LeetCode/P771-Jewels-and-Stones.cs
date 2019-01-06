namespace LeetCode.P771
{
    using System.Collections.Generic;

    public class Solution
    {
        public int NumJewelsInStones(string J, string S)
        {
            var j = new HashSet<char>(J.ToCharArray());
            if (j.Count == 0) return 0;
            var cs = S.ToCharArray();
            var len = cs.Length;
            var total = 0;
            for (var i = 0; i < len; i++) if (j.Contains(cs[i])) total++;
            return total;
        }
    }
}
