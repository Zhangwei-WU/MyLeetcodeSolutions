﻿

namespace LeetCode.P136
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            var result = 0;
            for (int i = 0, l = nums.Length; i < l; ++i) result ^= nums[i];
            return result;
        }
    }
}
