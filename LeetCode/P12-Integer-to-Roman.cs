namespace LeetCode.P12
{
    using System.Text;

    public class Solution
    {
        private static readonly string[] thousands = new string[] { "M", "MM", "MMM" };
        private static readonly string[] hundreds = new string[] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private static readonly string[] tens = new string[] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private static readonly string[] digits = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        public string IntToRoman(int num)
        {
            var sb = new StringBuilder(12);
            if (num >= 1000)
            {
                var n = num / 1000;
                num -= (n * 1000);
                sb.Append(thousands[n - 1]);
            }

            if (num >= 100)
            {
                var n = num / 100;
                num -= (n * 100);
                sb.Append(hundreds[n - 1]);
            }

            if (num >= 10)
            {
                var n = num / 10;
                num -= (n * 10);
                sb.Append(tens[n - 1]);
            }

            if(num > 0) sb.Append(digits[num - 1]);
            
            return sb.ToString();
        }
    }
}
