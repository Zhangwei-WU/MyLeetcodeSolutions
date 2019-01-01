namespace LeetCode.P344
{
    public class Solution
    {
        public string ReverseString(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            
            var chars = s.ToCharArray();
            var len = chars.Length;
            var half = len-- / 2;
            for (var i = 0; i < half; i++)
            {
                var c = chars[i];
                chars[i] = chars[len - i];
                chars[len - i] = c;
            }

            return new string(chars);
        }
    }
}
