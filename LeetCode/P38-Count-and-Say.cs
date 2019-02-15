
namespace LeetCode.P38
{
    using System.Text;

    public class Solution
    {
        public string CountAndSay(int n)
        {
            var result = new char[] { '1', '~' };

            for (var i = 1; i < n; ++i)
            {
                var cc = result[0];
                var sb = new StringBuilder(result.Length * 2);
                for (int j = 1, cn = 1; j < result.Length; ++j)
                {
                    var cj = result[j];
                    if (cj != cc)
                    {
                        sb.Append(cn.ToString());
                        sb.Append(cc);
                        cc = cj;
                        cn = 0;
                    }

                    ++cn;
                }

                sb.Append('~');
                var len = sb.Length;
                result = new char[len];
                sb.CopyTo(0, result, 0, len);
            }

            return new string(result, 0, result.Length - 1);
        }
    }
}
