/* Problem 166. Fraction to Recurring Decimal
 * https://leetcode.com/problems/fraction-to-recurring-decimal/description/
 * 
 * Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
 *
 * If the fractional part is repeating, enclose the repeating part in parentheses.
 *
 * For example,
 * Given numerator = 1, denominator = 2, return "0.5".
 * Given numerator = 2, denominator = 1, return "2".
 * Given numerator = 2, denominator = 3, return "0.(6)".
 * 
 * AC: 122ms
 */

namespace LeetCode.P166
{
    public class Solution
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            long n = numerator;
            long d = denominator;

            if (d < 0)
            {
                n = -n;
                d = -d;
            }

            var neg = n < 0L;
            if (neg) n = -n;

            var intpart = n / d;
            var fraction = n % d;

            var intpartstring = (neg ? "-" : string.Empty) + intpart.ToString();

            if (fraction == 0L) return intpartstring;

            return intpartstring + "." + FractionPart(fraction, d);
        }

        private string FractionPart(long fraction, long denominator)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            var cnt = 0;
            System.Collections.Generic.Dictionary<long, int> remainders = new System.Collections.Generic.Dictionary<long, int>();
            remainders.Add(fraction, cnt++);

            while (true)
            {
                if (fraction == 0) return sb.ToString();

                sb.Append((fraction *= 10) / denominator);
                fraction %= denominator;

                int idx;
                if (!remainders.TryGetValue(fraction, out idx)) remainders.Add(fraction, cnt++);
                else return sb.ToString(0, idx) + "(" + sb.ToString(idx, sb.Length - idx) + ")";
            }
        }
    }
}
