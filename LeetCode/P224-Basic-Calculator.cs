
namespace LeetCode.P224
{
    public class Solution
    {
        public int Calculate(string s)
        {
            var chars = s.ToCharArray();
            var index = 0;
            return Calculate(chars, ref index, chars.Length);
        }

        private int Calculate(char[] chars, ref int index, int length)
        {
            var op = '\0';
            int n1 = 0;
            bool n1Ready = false;
            while (index < length)
            {
                switch (chars[index++])
                {
                    case ' ':
                        break;
                    case '+':
                        op = '+';
                        break;
                    case '-':
                        op = '-';
                        break;
                    case '(':
                        var result1 = Calculate(chars, ref index, length);
                        if (!n1Ready)
                        {
                            n1 = result1;
                            n1Ready = true;
                        }
                        else
                        {
                            if (op == '+') n1 += result1;
                            else n1 -= result1;
                        }

                        break;
                    case ')':
                        return n1;
                    default:
                        var result2 = 0;
                        for (index--; index < length; index++)
                        {
                            var c = chars[index];
                            if (c >= '0' && c <= '9')
                            {
                                result2 *= 10;
                                result2 += (c - '0');
                            }
                            else break;
                        }

                        if (!n1Ready)
                        {
                            n1 = result2;
                            n1Ready = true;
                        }
                        else
                        {
                            if (op == '+') n1 += result2;
                            else n1 -= result2;
                        }
                        break;
                }
            }

            return n1;
        }
    }
}
