
namespace LeetCode.P844
{
    public class Solution
    {
        public bool BackspaceCompare(string S, string T)
        {
            var ss = S.ToCharArray();
            var ts = T.ToCharArray();
            
            int ssr = 0, tsr = 0;
            for (int i = 0, ssl = ss.Length; i < ssl; ++i)
            {
                if (ss[i] == '#') { if (ssr > 0) --ssr; }
                else ss[ssr++] = ss[i];
            }

            for (int i = 0, tsl = ts.Length; i < tsl; ++i)
            {
                if (ts[i] == '#') { if (tsr > 0) --tsr; }
                else ts[tsr++] = ts[i];
            }

            if (ssr != tsr) return false;
            for (var i = 0; i < ssr; i++) if (ss[i] != ts[i]) return false;
            return true;
        }
    }
}
