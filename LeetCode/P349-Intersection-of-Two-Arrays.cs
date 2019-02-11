﻿
namespace LeetCode.P349
{
    using System.Collections.Generic;

    public class Solution
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var hashset = new HashSet<int>(nums1);
            var result = new List<int>();

            for (var i = 0; hashset.Count != 0 && i < nums2.Length; i++)
            {
                if (hashset.Remove(nums2[i])) result.Add(nums2[i]);
            }

            return result.ToArray();
        }
    }
}
