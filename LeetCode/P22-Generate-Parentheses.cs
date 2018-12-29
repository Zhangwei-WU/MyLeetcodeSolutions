
namespace LeetCode.P22
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            char[] result = new char[n << 1];

            return Fill(result, 0, 0, 0, n << 1).ToArray();
        }

        private IEnumerable<string> Fill(char[] result, int index, int anchor, int lcount, int count)
        {
            if (index == count)
            {
                yield return new string(result);
                yield break;
            }

            if (lcount < (count >> 1))
            {
                result[index] = '(';
                foreach (var res in Fill(result, index + 1, anchor + 1, lcount + 1, count)) yield return res;
            }
            if (anchor > 0)
            {
                result[index] = ')';
                foreach (var res in Fill(result, index + 1, anchor - 1, lcount, count)) yield return res;
            }
        }
    }
}
