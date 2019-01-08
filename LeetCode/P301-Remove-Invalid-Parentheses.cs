namespace LeetCode.P301
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<string> RemoveInvalidParentheses(string s)
        {
            var chars = s.ToCharArray();
            var len = chars.Length;

            var stage = 0;
            var minstage = 0;
            for (var i = 0; i < len; i++)
            {
                var c = chars[i];

                if (c == '(') stage++;
                else if (c == ')') stage--;

                if (stage < minstage) minstage = stage;
            }

            if (stage == 0 && minstage == 0) return new string[] { s };
            return Dfs(chars, 0, len, stage - minstage, -minstage, 0).Distinct().ToArray();
        }

        private IEnumerable<string> Dfs(char[] chars, int index, int length, int left, int right, int stage)
        {
            if (left + right > length - index || stage - right > length - index) yield break;
            if (index == length)
            {
                yield return ToString(chars, length);
                yield break;
            }

            var c = chars[index];
            if (c == '(')
            {
                foreach (var s in Dfs(chars, index + 1, length, left, right, stage + 1)) yield return s;
                if (left > 0)
                {
                    chars[index] = '\0';
                    foreach (var s in Dfs(chars, index + 1, length, left - 1, right, stage)) yield return s;
                    chars[index] = '(';
                }
            }
            else if (c == ')')
            {
                if (stage > 0) foreach (var s in Dfs(chars, index + 1, length, left, right, stage - 1)) yield return s;
                if (right > 0)
                {
                    chars[index] = '\0';
                    foreach (var s in Dfs(chars, index + 1, length, left, right - 1, stage)) yield return s;
                    chars[index] = ')';
                }
            }
            else foreach (var s in Dfs(chars, index + 1, length, left, right, stage)) yield return s;
        }

        private string ToString(char[] chars, int length)
        {
            var sb = new System.Text.StringBuilder(length);
            foreach (var c in chars)
            {
                if (c == '\0') continue;
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
