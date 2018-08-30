/* Problem 58. Length of Last Word
 * https://leetcode.com/problems/length-of-last-word/description/ 
 * 
 * Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
 * If the last word does not exist, return 0.
 * 
 * Note: A word is defined as a character sequence consists of non-space characters only.
 * 
 * Example:
 * Input: "Hello World"
 * Output: 5
 * 
 */

namespace LeetCode.P58
{
    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            s = s.TrimEnd();
            var lastIndex = s.LastIndexOf(' ');
            if (lastIndex == -1) return s.Length;
            return s.Length - lastIndex - 1;
        }
    }
}
