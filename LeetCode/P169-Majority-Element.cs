
namespace LeetCode.P169
{
    using System;

    public class Solution
    {
        public int MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            return nums.Length % 2 != 0
                ? nums[nums.Length / 2]
                : nums[nums.Length / 2 - 1];
        }
    }
}
