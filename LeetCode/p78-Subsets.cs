/* Problem 78. Subsets
 * https://leetcode.com/problems/subsets/description/
 * 
 * Given a set of distinct integers, nums, return all possible subsets (the power set).
 * 
 * Note: The solution set must not contain duplicate subsets.
 * 
 * For example,
 * If nums = [1,2,3], a solution is:
 * [
 *   [3],
 *   [1],
 *   [2],
 *   [1,2,3],
 *   [1,3],
 *   [2,3],
 *   [1,2],
 *   []
 * ]
 * 
 */

namespace LeetCode.P78
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();
            result.Add(new List<int>());

            var len = nums.Length;
            if (len == 0) return result;

            var max = 1 << len;
            var curr = 0;

            result.Capacity = max;

            while (++curr < max)
            {
                var data = new List<int>(len);
                var temp = curr;

                for (var i = 0; i < len && temp != 0; i++, temp >>= 1)
                    if ((temp & 1) == 1) data.Add(nums[i]);

                result.Add(data);
            }

            return result;
        }
    }
}
