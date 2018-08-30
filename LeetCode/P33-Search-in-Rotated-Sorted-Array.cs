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
            for (int start = 0, end = nums.Length - 1; start <= end;)
            {
                var nstart = nums[start];
                if (target == nstart) return start;

                var nend = nums[end];
                if (target == nend) return end;
                if (nstart <= nend) return BinarySearch(nums, start + 1, end - start - 1, target);

                var mid = (start + end) / 2;
                var nmid = nums[mid];
                if (target == nmid) return mid;

                if (nstart < nmid)
                {
                    if (target > nstart && target < nmid) return BinarySearch(nums, start + 1, mid - start - 1, target);
                    start = mid + 1;
                }
                else
                {
                    if (target > nmid && target < nend) return BinarySearch(nums, mid + 1, end - mid - 1, target);
                    end = mid - 1;
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
                int order = array[i] - value;

                if (order == 0) return i;

                if (order < 0) lo = i + 1;
                else hi = i - 1;
            }

            return -1;
        }
    }

}
