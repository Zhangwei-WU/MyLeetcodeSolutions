namespace LeetCode.P91
{
    public class Solution
    {
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var c = s.ToCharArray();
            var len = c.Length;
            if (len == 1) return c[0] == '0' ? 0 : 1;

            var n2 = c[len - 1] != '0' ? 1 : 0;
            var n1 = (c[len - 2] != '0' ? 1 : 0) * n2 + (c[len - 2] == '1' || c[len - 2] == '2' && c[len - 1] <= '6' ? 1 : 0);

            for (var i = len - 3; i >= 0; i--)
            {
                var n = (c[i] > '0' ? 1 : 0) * n1 + (c[i] == '1' || c[i] == '2' && c[i + 1] <= '6' ? 1 : 0) * n2;
                n2 = n1;
                n1 = n;
            }

            return n1;
        }
    }
}
