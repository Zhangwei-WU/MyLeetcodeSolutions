
namespace LeetCode.P67
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            if (b.Length > a.Length) { var t = a; a = b; b = t; }

            var result = ("0" + a).ToCharArray();
            var add = b.ToCharArray();

            var resultLen = result.Length;

            for (int addLen = add.Length, i = addLen - 1, diff = resultLen - addLen; i >= 0; i--)
            {
                if (add[i] == '0') continue;
                for (var j = diff + i; j >= 0; j--)
                {
                    if (result[j] == '0')
                    {
                        result[j] = '1';
                        break;
                    }

                    result[j] = '0';
                }
            }

            for (var i = 0; i < resultLen; i++)
            {
                if (result[i] == '0') continue;
                return new string(result, i, resultLen - i);
            }

            return "0";
        }
    }
}
