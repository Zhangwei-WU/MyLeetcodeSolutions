namespace LeetCode.P32
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            var len = s.Length;
            var pos = new int[len + 1];

            var cs = s.ToCharArray();

            for (int i = 0, prev = 0; i < len; i++)
            {
                prev = pos[i + 1] = prev + (cs[i] == '(' ? 1 : -1);
            }

            var maxlen = 0;

            for (var i = 0; i < len - maxlen; i++)
            {
                var b = pos[i];
                var cp1 = pos[i + maxlen] - b;
                if (cp1 < 0 || cp1 > len - i - maxlen) continue;

                for (int j = i + 1; j <= len;)
                {
                    var cp = pos[j] - b;
                    if (cp < 0)
                    {
                        i = j - 1;
                        break;
                    }

                    if (cp == 0)
                    {
                        var clen = j - i;
                        if (clen > maxlen) maxlen = clen;
                        j++;
                    }
                    else j += cp;
                }
            }

            return maxlen;
        }
    }
}
