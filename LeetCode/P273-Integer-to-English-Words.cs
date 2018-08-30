/* Problem 273. Integer to English Words
 * https://leetcode.com/problems/integer-to-english-words/description/
 * 
 * Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 2^31 - 1.

 * For example,
 * 123 -> "One Hundred Twenty Three"
 * 12345 -> "Twelve Thousand Three Hundred Forty Five"
 * 1234567 -> "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
 * 
 */

namespace LeetCode.P273
{
    public class Solution
    {
        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            System.Collections.Generic.List<string> parts = new System.Collections.Generic.List<string>(10);

            int part = 0;
            while (num != 0)
            {
                var partial = num % 1000;

                if (partial != 0)
                {
                    if(part != 0) parts.Add(suffix[part]);
                    parts.Add(ToWords(partial));
                }

                num /= 1000;
                part++;
            }

            parts.Reverse();
            return string.Join(" ", parts);
        }

        string[] suffix = new string[] { string.Empty, "Thousand", "Million", "Billion" };
        string[] singlenums = new string[] {
            string.Empty, "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] tensnums = new string[] { string.Empty, string.Empty, "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        private string ToWords(int num)
        {
            var sb = new System.Text.StringBuilder(30);
            if (num >= 100)
            {
                var n = num / 100;
                num %= 100;
                sb.Append(singlenums[n]);
                sb.Append(" Hundred");
            }

            if (num != 0 && sb.Length != 0) sb.Append(' ');

            if (num >= 20)
            {
                var n = num / 10;
                sb.Append(tensnums[n]);
                num %= 10;
                if (num != 0)
                {
                    sb.Append(' ');
                    sb.Append(singlenums[num]);
                }
            }
            else sb.Append(singlenums[num]);

            return sb.ToString();
        }
    }
}
