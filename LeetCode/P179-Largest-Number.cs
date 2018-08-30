/* Problem 179: Largest Number
 * https://leetcode.com/problems/largest-number/description/
 * 
 * Given a list of non negative integers, arrange them such that they form the largest number.
 * 
 * For example, given [3, 30, 34, 5, 9], the largest formed number is 9534330.
 * 
 * Note: The result may be very large, so you need to return a string instead of an integer.
 * 
 * AC: 189ms
 */

namespace LeetCode.P179
{
    using System;
    using System.Text;

    public class Solution
    {
        public string LargestNumber(int[] nums)
        {
            string[] strs = new string[nums.Length];
            var totalLen = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var str = nums[i].ToString();
                totalLen += str.Length;
                strs[i] = str;
            }

            if (totalLen == 0) return string.Empty;

            Array.Sort(strs, (x, y) => string.CompareOrdinal(y + x, x + y));
            var sb = new StringBuilder(totalLen);
            for (var i = 0; i < nums.Length; i++)
            {
                sb.Append(strs[i]);
            }

            var num = sb.ToString().TrimStart('0');
            return num.Length == 0 ? "0" : num;
        }
    }
}
