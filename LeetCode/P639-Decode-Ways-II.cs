
namespace LeetCode.P639
{
    public class Solution
    {
        const int mod = 1000000007;
        public int NumDecodings(string s)
        {
            var cs = s.ToCharArray();
            var l = cs.Length;
            var mem = new int[l];
            for (var i = 0; i < l; ++i) mem[i] = int.MinValue;
            var result = NumDecodings(cs, 0, l, mem, false, false);
            return result % mod;
        }

        public int NumDecodings(char[] s, int index, int length, int[] mem, bool check, bool wild)
        {
            if (index == length) return check ? 0 : 1;

            var c = s[index];

            if (check)
            {
                if (c == '*')
                {
                    var cnt = 0;
                    for (var i = '1'; i <= '9'; ++i)
                    {
                        s[index] = i;
                        cnt += NumDecodings(s, index, length, mem, true, true);
                        if (cnt > mod) cnt -= mod;
                    }
                    s[index] = '*';
                    return cnt;
                }
                else if (c <= '6')
                {
                    return s[index - 1] == '1' || s[index - 1] == '2'
                        ? NumDecodings(s, index + 1, length, mem, false, false)
                        : 0;
                }
                else
                {
                    return s[index - 1] == '1'
                        ? NumDecodings(s, index + 1, length, mem, false, false)
                        : 0;
                }
            }
            else
            {
                if (mem[index] != int.MinValue) return mem[index];

                if (c == '0') return mem[index] = 0;
                else if (c == '*')
                {
                    var cnt = 0;
                    for (var i = '1'; i <= '9'; ++i)
                    {
                        s[index] = i;
                        cnt += NumDecodings(s, index, length, mem, false, true);
                        if (cnt > mod) cnt -= mod;
                    }
                    s[index] = '*';
                    return mem[index] = cnt;
                }
                else
                {
                    var result = NumDecodings(s, index + 1, length, mem, false, false)
                        + NumDecodings(s, index + 1, length, mem, true, false);
                    if (result > mod) result -= mod;
                    if (!wild) mem[index] = result;
                    return result;
                }
            }
        }
    }
}
