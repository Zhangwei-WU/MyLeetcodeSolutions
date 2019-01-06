
namespace LeetCode.P10
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            return IsMatch(s.ToCharArray(), 0, s.Length, p.ToCharArray(), 0, p.Length);
        }

        private bool IsMatch(char[] s, int si, int sl, char[] p, int pi, int pl)
        {
            if (si == sl && pi == pl) return true;
            if (pi == pl) return false;

            var c = p[pi++];
            int mi = 1, ma = sl - si;
            if (pi < pl && p[pi] == '*' && (mi = 0) == 0) pi++;
            else if (ma == 0) return false;
            else ma = 1;

            var acttry = c == '.' ? ma : 0;
            if (acttry == 0) for (var i = acttry; i < ma && s[si + i] == c; i++) acttry++;
            for (var i = acttry; i >= mi; i--) if (IsMatch(s, si + i, sl, p, pi, pl)) return true;

            return false;
        }
    }
}
