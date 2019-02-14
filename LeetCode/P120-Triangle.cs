
namespace LeetCode.P120
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var l = triangle.Count;
            for (var i = 1; i < l; ++i)
            {
                var thisrow = triangle[i];
                var lastrow = triangle[i - 1];
                thisrow[0] += lastrow[0];
                for (var j = 1; j < i; ++j)
                {
                    thisrow[j] += Math.Min(lastrow[j - 1], lastrow[j]);
                }

                thisrow[i] += lastrow[i - 1];
            }

            var last = triangle[l - 1];
            var min = int.MaxValue;
            for (var i = 0; i < last.Count; ++i) if (last[i] < min) min = last[i];

            return min;
        }
    }
}
