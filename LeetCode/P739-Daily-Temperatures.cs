/* Problem 739. Daily Temperatures
 * https://leetcode.com/problems/daily-temperatures/description/
 * 
 * Given a list of daily temperatures, produce a list that, for each day in the input, tells you how many days you would have to wait until a warmer temperature. If there is no future day for which this is possible, put 0 instead.
 * 
 * For example, given the list temperatures = [73, 74, 75, 71, 69, 72, 76, 73], your output should be [1, 1, 4, 2, 1, 1, 0, 0].
 * 
 * Note: The length of temperatures will be in the range [1, 30000]. Each temperature will be an integer in the range [30, 100].
 */

namespace LeetCode.P739
{
    using System.Collections.Generic;
    public class Solution
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            var len = temperatures.Length;
            var result = new int[len];

            Stack<KeyValuePair<int, int>> stack = new Stack<KeyValuePair<int, int>>(len);
            for (var i = 0; i < len; i++)
            {
                while(stack.Count != 0 && stack.Peek().Key < temperatures[i])
                {
                    var prev = stack.Pop().Value;
                    result[prev] = i - prev;
                }

                stack.Push(new KeyValuePair<int, int>(temperatures[i], i));
            }

            return result;
        }
    }
}
