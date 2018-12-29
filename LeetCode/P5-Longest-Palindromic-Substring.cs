namespace LeetCode.P5
{
    using System.Collections.Generic;

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            var cs = s.ToCharArray();
            var len = cs.Length;

            var lp = new KeyValuePair<int, int>(0, 1);

            for (var i = 0; i < len; i++)
            {
                var pos = TestPosition(cs, len, i);
                if (pos.Value > lp.Value) lp = pos;
            }

            return s.Substring(lp.Key, lp.Value);
        }

        public KeyValuePair<int, int> TestPosition(char[] arr, int len, int pos)
        {
            var index1 = pos;
            var length1 = 1;
            for (var i = pos - 1; i >= 0 && pos + pos - i < len; i--)
            {
                if (arr[i] != arr[pos + pos - i]) break;
                index1 = i;
                length1 += 2;
            }

            var index2 = pos;
            var length2 = 0;
            for (var i = pos; i >= 0 && pos + pos - i + 1 < len; i--)
            {
                if (arr[i] != arr[pos + pos - i + 1]) break;
                index2 = i;
                length2 += 2;
            }

            return length1 > length2 ? new KeyValuePair<int, int>(index1, length1) : new KeyValuePair<int, int>(index2, length2);
        }
    }
}
