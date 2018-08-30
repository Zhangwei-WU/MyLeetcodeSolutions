/* Problem 66. Plus One
 * https://leetcode.com/problems/plus-one/description/
 * 
 * Given a non-negative integer represented as a non-empty array of digits, plus one to the integer.
 * You may assume the integer do not contain any leading zero, except the number 0 itself.
 * The digits are stored such that the most significant digit is at the head of the list.
 * 
 */

namespace LeetCode.P66
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            var len = digits.Length;
            for (var i = len - 1; i >= 0; digits[i--] = 0)
                if (digits[i]++ != 9) return digits;

            var newdigits = new int[len + 1];
            newdigits[0] = 1;
            return newdigits;
        }
    }
}
