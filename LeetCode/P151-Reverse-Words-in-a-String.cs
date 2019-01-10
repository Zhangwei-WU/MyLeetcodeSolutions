namespace LeetCode.P151
{
    public class Solution
    {
        public string ReverseWords(string s)
        {
            var chars = s.ToCharArray();
            var len = chars.Length;
            var result = new char[len];
            var rlen = 0;
            for (int i = len - 1, j = len; i >= -1; i--)
            {
                if (i == -1 || chars[i] == ' ') // copy [i + 1, j]
                {
                    if (i + 1 != j)
                    {
                        for (var k = i + 1; k < j; k++) result[rlen++] = chars[k];
                        if (i != -1) result[rlen++] = ' ';
                    }

                    j = i;
                }
            }

            if (rlen != 0 && result[rlen - 1] == ' ') rlen--;
            return new string(result, 0, rlen);
        }
    }
}
