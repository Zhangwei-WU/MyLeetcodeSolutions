namespace LeetCode.P8
{
    public class Solution
    {
        public int MyAtoi(string str)
        {
            var len = str.Length;
            if (len == 0) return 0;

            var chars = str.ToCharArray();
            var i = 0;
            for (; i < len; i++) if (chars[i] != ' ') break;
            if (i == len) return 0;

            bool neg = false;
            var schar = chars[i];
            if (schar == '-') { neg = true; i++; }
            else if (schar == '+') { i++; }

            var result = 0L;
            for (; i < len; i++)
            {
                var n = chars[i] - '0';
                if (n < 0 || n > 9) break;
                result = result * 10 + n;

                if (result >= int.MaxValue)
                {
                    if (!neg) return int.MaxValue;
                    else if (result >= int.MaxValue + 1L) return int.MinValue;
                }
            }

            return neg ? -(int)result : (int)result;
        }
    }
}
