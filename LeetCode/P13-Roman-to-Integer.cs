namespace LeetCode.P13
{

    public class Solution
    {
        //private static readonly string[] thousands = new string[] { "M", "MM", "MMM" };
        //private static readonly string[] hundreds = new string[] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        //private static readonly string[] tens = new string[] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        //private static readonly string[] digits = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        public int RomanToInt(string s)
        {
            int val = 0;
            if (string.IsNullOrEmpty(s)) return val;

            var chars = s.ToCharArray();
            var len = chars.Length;
            var i = 0;
            while (i != len)
            {
                var c = chars[i++];
                if (c == 'M') val += 1000;
                else if (c == 'D') val += 500;
                else if (c == 'L') val += 50;
                else if (c == 'V') val += 5;
                else if (c == 'C')
                {
                    val += 100;
                    if (i == len) break;
                    var nc = chars[i++];
                    if (nc == 'M') val += 800;
                    else if (nc == 'D') val += 300;
                    else if (nc == 'C')
                    {
                        val += 100;
                        if (i == len) break;
                        if (chars[i++] == 'C') val += 100;
                        else i--;
                    }
                    else i--;
                }
                else if (c == 'X')
                {
                    val += 10;
                    if (i == len) break;
                    var nc = chars[i++];
                    if (nc == 'C') val += 80;
                    else if (nc == 'L') val += 30;
                    else if (nc == 'X')
                    {
                        val += 10;
                        if (i == len) break;
                        if (chars[i++] == 'X') val += 10;
                        else i--;
                    }
                    else i--;
                }
                else if (c == 'I')
                {
                    val += 1;
                    if (i == len) break;
                    var nc = chars[i++];
                    if (nc == 'X') val += 8;
                    else if (nc == 'V') val += 3;
                    else if (nc == 'I')
                    {
                        val += 1;
                        if (i == len) break;
                        if (chars[i++] == 'I') val += 1;
                        else i--;
                    }
                    else i--;
                }
            }

            return val;
        }
    }
}
