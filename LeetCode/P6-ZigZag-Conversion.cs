namespace LeetCode.P6
{
    using System.Text;

    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || string.IsNullOrEmpty(s)) return s;
            var len = s.Length;

            var sb = new StringBuilder(len);
            var step = 2 * numRows - 2;
            // first row
            for (var i = 0; i < len; i += step) sb.Append(s[i]);
            for (var i = 1; i < numRows - 1; ++i)
            {
                for (var j = i; j < len; j += step)
                {
                    sb.Append(s[j]);
                    var other = j + step - 2 * i;
                    if (other >= len) break;
                    sb.Append(s[other]);
                }
            }

            // last row
            for (var i = numRows - 1; i < len; i += step) sb.Append(s[i]);

            return sb.ToString();
        }
    }
}
