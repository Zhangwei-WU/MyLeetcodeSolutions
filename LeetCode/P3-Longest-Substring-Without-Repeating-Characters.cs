/* Problem 3: Longest Substring Without Repeating Characters
 * https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
 * 
 * Given a string, find the length of the longest substring without repeating characters.
 *
 * Examples:
 *
 * Given "abcabcbb", the answer is "abc", which the length is 3.
 * Given "bbbbb", the answer is "b", with the length of 1.
 * Given "pwwkew", the answer is "wke", with the length of 3. 
 * 
 * Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
 */

namespace LeetCode.P3
{
    using System.Collections.Generic;

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var len = s.Length;
            int[] pos = new int[len];

            Dictionary<char, int> lastPos = new Dictionary<char, int>(128);
            var chars = s.ToCharArray();
            for (var i = len - 1; i >= 0; i--)
            {
                var c = chars[i];
                var p = 0;
                if (!lastPos.TryGetValue(c, out p))
                {
                    pos[i] = len;
                    lastPos.Add(c, i);
                }
                else
                {
                    pos[i] = p;
                    lastPos[c] = i;
                }
            }

            var max = 0;
            var curr = 0;
            for (int i = 0, j = 0; i < len && j != len; i++)
            {
                var endl = pos[i];
                if (endl == len)
                {
                    curr++;
                    continue;
                }

                j = i + 1;
                for (; j < endl; j++)
                {
                    if (pos[j] < endl) endl = pos[j];
                }

                curr += (j - i);
                if (curr > max) max = curr;
                curr = 0;
            }

            return curr > max ? curr : max;
        }
    }
}
