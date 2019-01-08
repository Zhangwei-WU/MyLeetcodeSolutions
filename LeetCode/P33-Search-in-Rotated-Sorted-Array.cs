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
            for (int lo = 0, hi = nums.Length - 1; lo <= hi;)
            {
                var nlo = nums[lo];
                if (target == nlo) return lo;

                var nhi = nums[hi];
                if (target == nhi) return hi;
                if (nlo <= nhi) return BinarySearch(nums, lo + 1, hi - lo - 1, target);

                var mid = (lo + hi) >> 1;
                var nmid = nums[mid];
                if (target == nmid) return mid;

                if (nlo < nmid)
                {
                    if (target > nlo && target < nmid) return BinarySearch(nums, lo + 1, mid - lo - 1, target);
                    lo = mid + 1;
                }
                else
                {
                    if (target > nmid && target < nhi) return BinarySearch(nums, mid + 1, hi - mid - 1, target);
                    hi = mid - 1;
                }
            }

            return -1;
        }

        private int BinarySearch(int[] array, int index, int length, int value)
        {
            int lo = index;
            int hi = index + length - 1;
            while (lo <= hi)
            {
                int i = lo + ((hi - lo) >> 1);
                int cp = array[i] - value;

                if (cp == 0) return i;

                if (cp < 0) lo = i + 1;
                else hi = i - 1;
            }

            return -1;
        }
    }

}
