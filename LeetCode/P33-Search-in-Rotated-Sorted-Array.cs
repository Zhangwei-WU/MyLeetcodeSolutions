/* Problem 33: Search in Rotated Sorted Array
 * https://leetcode.com/problems/search-in-rotated-sorted-array/description/
 * 
 * Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
 * (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
 * You are given a target value to search. If found in the array return its index, otherwise return -1.
 * You may assume no duplicate exists in the array.
 * 
 * AC: 196ms
 */

namespace LeetCode.P33
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            for (int l = 0, h = nums.Length - 1; l <= h;)
            {
                var m = l + (h - l) / 2;
                var cp = nums[m] - target;
                if (cp == 0) return m;

                if (nums[l] <= nums[m])
                {
                    if (target >= nums[l] && cp > 0) h = m - 1;
                    else l = m + 1;
                }
                else
                {
                    if (target <= nums[h] && cp < 0) l = m + 1;
                    else h = m - 1;
                }
            }

            return -1;
        }
    }
}
