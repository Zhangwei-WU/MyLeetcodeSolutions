/* Problem 231. Power of Two
 * https://leetcode.com/problems/power-of-two/description/
 * 
 * Given an integer, write a function to determine if it is a power of two.
 */

namespace LeetCode.P231
{
    public class Solution
    {
        public bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }
    }
}
