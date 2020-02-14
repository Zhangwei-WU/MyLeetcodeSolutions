
namespace LeetCode.P1106
{
    using System;
    public class Solution
    {
        public bool ParseBoolExpr(string expression)
        {
            var cs = expression.ToCharArray();
            var index = 0;
            return ParseBoolExpr(cs, ref index);
        }

        private bool ParseBoolExpr(char[] cs, ref int index)
        {
            switch (cs[index++])
            {
                case '(':
                    var res1 = ParseBoolExpr(cs, ref index);
                    ++index;
                    return res1;

                case 'f':
                    return false;

                case 't':
                    return true;

                case '!':
                    return !ParseBoolExpr(cs, ref index);

                case '&':
                    var res2 = true;

                    while (cs[index++] != ')') res2 &= ParseBoolExpr(cs, ref index);

                    return res2;

                case '|':
                    var res3 = false;

                    while (cs[index++] != ')') res3 |= ParseBoolExpr(cs, ref index);

                    return res3;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
