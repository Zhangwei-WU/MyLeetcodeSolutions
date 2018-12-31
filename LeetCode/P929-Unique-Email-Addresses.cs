
namespace LeetCode.P929
{
    using System.Collections.Generic;

    public class Solution
    {
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> unique = new HashSet<string>(emails.Length);

            foreach (var email in emails)
            {
                var length = email.Length;
                var chars = email.ToCharArray();
                var atIndex = -1;
                for (var i = length - 1; i >= 0; i--)
                {
                    if (chars[i] != '@') continue;
                    atIndex = i;
                    break;
                }

                var len = 0;
                for (var i = 0; i < atIndex; i++)
                {
                    var c = chars[i];
                    if (c == '.') continue;
                    if (c == '+') break;
                    if (i == len) continue;
                    chars[len++] = c;
                }

                unique.Add(new string(chars, 0, len) + new string(chars, atIndex, length - atIndex));
            }

            return unique.Count;
        }
    }
}
