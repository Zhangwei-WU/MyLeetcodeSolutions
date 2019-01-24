
namespace LeetCode.P34
{
    using System;

    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var pos = Array.BinarySearch(nums, target);
            if (pos < 0) return new int[] { -1, -1 };
            int len = nums.Length, upper = pos, lower = pos;

            while (upper >= 0) upper = Array.BinarySearch(nums, upper + 1, len - upper - 1, target);
            while (lower >= 0) lower = Array.BinarySearch(nums, 0, lower, target);

            return new int[] { ~lower, ~upper - 1 };
        }
    }
}
