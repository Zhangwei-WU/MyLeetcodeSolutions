/* Problem 55. Jump Game
 * https://leetcode.com/problems/jump-game/description/
 * 
 * Given an array of non-negative integers, you are initially positioned at the first index of the array.
 * Each element in the array represents your maximum jump length at that position.
 * Determine if you are able to reach the last index.
 * 
 * For example:
 * A = [2,3,1,1,4], return true.
 * A = [3,2,1,0,4], return false.
 * 
 */

namespace LeetCode.P55
{
    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            int r = 0, t = nums.Length - 1;

            for (int i = 0; i <= t; i++)
            {
                if (i > r) return false;
                int c = nums[i] + i;
                if (c > r) r = c;
                if (r >= t) return true;
            }

            return true;
        }
    }
}
