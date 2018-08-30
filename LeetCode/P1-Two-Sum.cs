/* Problem 1: Two Sum  
 * https://leetcode.com/problems/two-sum/description/
 * 
 * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
 * You may assume that each input would have exactly one solution, and you may not use the same element twice.
 * 
 * Example:
 * Given nums = [2, 7, 11, 15], target = 9,
 * Because nums[0] + nums[1] = 2 + 7 = 9,
 * return [0, 1].
 */

namespace LeetCode.P1
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            KeyValuePair<int, int>[] pairs = new KeyValuePair<int, int>[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                pairs[i] = new KeyValuePair<int, int>(nums[i], i);
            }

            Array.Sort(pairs, (x, y) => x.Key - y.Key);
            
            for(int startIndex = 0, endIndex = nums.Length - 1; startIndex < endIndex; )
            {
                var compare = target - pairs[startIndex].Key - pairs[endIndex].Key;
                if (compare < 0)
                {
                    endIndex--;
                    continue;
                }
                else if (compare > 0)
                {
                    startIndex++;
                    continue;
                }

                var index1 = pairs[startIndex].Value;
                var index2 = pairs[endIndex].Value;

                return index1 < index2 ? new int[] { index1, index2 } : new int[] { index2, index1 };
            }
            
            throw new NotImplementedException();
        }
    }
}
