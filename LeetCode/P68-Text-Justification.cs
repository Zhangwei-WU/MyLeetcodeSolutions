/* Problem 68: Text Justification
 * https://leetcode.com/problems/text-justification/description/
 * 
 * Given an array of words and a length L, format the text such that each line has exactly L characters and is fully (left and right) justified.
 * You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly L characters.
 * Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line do not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.
 * For the last line of text, it should be left justified and no extra space is inserted between words.
 * 
 * For example,
 * words: ["This", "is", "an", "example", "of", "text", "justification."]
 * L: 16.
 * 
 * Return the formatted lines as:
 * [
 *   "This    is    an",
 *   "example  of text",
 *   "justification.  "
 * ]
 * 
 * Note: Each word is guaranteed not to exceed L in length.
 * 
 */

namespace LeetCode.P68
{
    using System.Collections.Generic;
    using System.Text;

    public class Solution
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            if (maxWidth == 0) return words;
            var len = words.Length;
            var sb = new StringBuilder(maxWidth * len);

            int cacheStart = 0;
            int cacheCount = 0;

            for (int i = 0, iter = 0; i < len; i++)
            {
                var w = words[i];
                if (iter + w.Length > maxWidth)
                {
                    sb.Append(words[cacheStart]);

                    var spaceCount = maxWidth - iter + cacheCount;
                    if (cacheCount == 1)
                    {
                        sb.Append(' ', spaceCount);
                    }
                    else
                    {
                        int spaces = cacheCount - 1, distrib = spaceCount / spaces, additional = spaceCount % spaces;
                        for (int j = 1; j < cacheCount; j++)
                        {
                            sb.Append(' ', distrib + (j <= additional ? 1 : 0));
                            sb.Append(words[cacheStart + j]);
                        }
                    }

                    cacheStart = i;
                    cacheCount = 0;
                    iter = 0;
                }

                cacheCount++;
                iter += (w.Length + 1);
            }

            var lens = sb.Length;
            sb.Append(words[cacheStart]);
            for (var i = 1; i < cacheCount; i++)
            {
                sb.Append(' ');
                sb.Append(words[cacheStart + i]);
            }

            sb.Append(' ', maxWidth + lens - sb.Length);

            lens = sb.Length;
            var cnt = lens / maxWidth;
            List<string> result = new List<string>(cnt);
            for (var i = 0; i < lens; i += maxWidth)
            {
                result.Add(sb.ToString(i, maxWidth));
            }

            return result;
        }
    }
}
