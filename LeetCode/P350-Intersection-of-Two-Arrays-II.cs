
namespace LeetCode.P350
{
    using System.Collections.Generic;

    public class Solution
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var set = new Dictionary<int, int>();
            var result = new List<int>();
            for (var i = 0; i < nums1.Length; ++i)
            {
                if (set.TryGetValue(nums1[i], out int v)) set[nums1[i]] = v + 1;
                else set.Add(nums1[i], 1);
            }

            for (var i = 0; set.Count != 0 && i < nums2.Length; ++i)
            {
                if (set.TryGetValue(nums2[i], out int v))
                {
                    result.Add(nums2[i]);
                    if (v == 1) set.Remove(nums2[i]);
                    else set[nums2[i]] = v - 1;
                }
            }

            return result.ToArray();
        }
    }
}
