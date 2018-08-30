/* Problem 258. Add Digits
 * https://leetcode.com/problems/add-digits/description/ 
 * 
 * Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.
 * 
 * For example: Given num = 38, the process is like: 3 + 8 = 11, 1 + 1 = 2. Since 2 has only one digit, return it.
 * Follow up: Could you do it without any loop/recursion in O(1) runtime?
 */

namespace LeetCode.P258
{
    public class Solution
    {
        public int AddDigits(int num)
        {
            var val = 0;
            while (num != 0)
            {
                if ((val += num % 10) > 9) val -= 9;
                num /= 10;
            }

            return val;
        }
    }
}
