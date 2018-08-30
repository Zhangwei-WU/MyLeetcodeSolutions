/* Problem 633. Sum of Square Numbers
 * https://leetcode.com/problems/sum-of-square-numbers/description/ 
 * 
 * Given a non-negative integer c, your task is to decide whether there're two integers a and b such that a2 + b2 = c.
 * 
 * Example 1:
 * Input: 5
 * Output: True
 * Explanation: 1 * 1 + 2 * 2 = 5
 * 
 * Example 2:
 * Input: 3
 * Output: False
 */

namespace LeetCode.P633
{
    using System;
    
    public class Solution
    {
        public bool JudgeSquareSum(int c)
        {
            for (int i = 0, sqrt = (int)Math.Sqrt(c / 2.0d); i <= sqrt; i++)
            {
                var root = Math.Sqrt(c - i * i);
                if (root - (int)root <= double.Epsilon) return true;
            }

            return false;
        }
    }
}
