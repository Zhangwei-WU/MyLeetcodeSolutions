
namespace LeetCode.P57
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var len = intervals.Length;
            var newarr = new KeyValuePair<int, int>[(len << 1) + 2];
            for (var i = 0; i < len; ++i)
            {
                newarr[i << 1] = new KeyValuePair<int, int>(intervals[i][0], -1);
                newarr[(i << 1) + 1] = new KeyValuePair<int, int>(intervals[i][1], 1);
            }

            newarr[len << 1] = new KeyValuePair<int, int>(newInterval[0], -1);
            newarr[(len << 1) + 1] = new KeyValuePair<int, int>(newInterval[1], 1);

            Array.Sort(newarr, (a, b) => a.Key == b.Key ? a.Value - b.Value : a.Key - b.Key);

            var result = new List<int[]>();

            var cnt = 0;
            var start = 0;

            foreach (var kv in newarr)
            {
                cnt += kv.Value;
                if (cnt == -1 && kv.Value == -1) start = kv.Key;
                if (cnt == 0) result.Add(new int[] { start, kv.Key });
            }

            return result.ToArray();
        }
    }
}
