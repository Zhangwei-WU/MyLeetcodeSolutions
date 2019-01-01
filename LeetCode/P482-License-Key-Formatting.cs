namespace LeetCode.P482
{

    public class Solution
    {
        public string LicenseKeyFormatting(string S, int K)
        {
            var len = S.Length;
            var chars = S.ToCharArray();
            var result = new char[len * 2];
            var index = result.Length - 1;
            for (int i = len - 1, counter = 0; i >= 0; i--)
            {
                var c = chars[i];
                if (c == '-') continue;
                if (c >= 'a' && c <= 'z') c = (char)(c - 32);
                if (counter == K) { result[index--] = '-'; counter = 0; }
                result[index--] = c;
                counter++;
            }

            return new string(result, index + 1, result.Length - index - 1);
        }
    }
}
