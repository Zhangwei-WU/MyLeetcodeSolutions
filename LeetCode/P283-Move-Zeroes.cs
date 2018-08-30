/* Problem 283. Move Zeroes
 * https://leetcode.com/problems/move-zeroes/description/
 * 
 * Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
 * 
 * For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0].
 * 
 * Note: You must do this in-place without making a copy of the array. Minimize the total number of operations.
 */

namespace LeetCode.P283
{
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            var len = nums.Length;
            var iter = 0;
            for (var i = 0; i < len; i++)
            {
                var curr = nums[i];
                if (curr != 0)
                {
                    if (i != iter) nums[iter] = curr;
                    iter++;
                }
            }

            for (var i = iter; i < len; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
