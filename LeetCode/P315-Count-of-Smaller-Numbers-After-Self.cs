/// <summary>
/// TLE
/// </summary>

namespace LeetCode.P315
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<int> CountSmaller(int[] nums)
        {
            var len = nums.Length;
            var result = new int[len];

            for (var i = len - 2; i >= 0; i--)
            {
                var cnt = 0;
                for (var j = i + 1; j < len; j++) if (nums[j] < nums[i]) cnt++;
                result[i] = cnt;
            }

            return result;
        }
    }
}
