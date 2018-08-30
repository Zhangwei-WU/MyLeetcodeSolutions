/* Problem 56. Merge Intervals
 * https://leetcode.com/problems/merge-intervals/description/
 * 
 * Given a collection of intervals, merge all overlapping intervals.
 * 
 * For example,
 * Given [1,3],[2,6],[8,10],[15,18],
 * return [1,6],[8,10],[15,18].
 * 
 */

namespace LeetCode.P56
{
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }
}

namespace LeetCode.P56
{
    using System;
    using System.Collections.Generic;
    
    public class Solution
    {
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            var cnt = intervals.Count;
            if (cnt <= 1) return intervals;

            var lcnt = cnt * 2;
            var array = new Interval[lcnt + 1];
            array[lcnt] = new Interval(int.MaxValue, 1);

            for (int i = 0, idx = 0; i < cnt; i++)
            {
                var interval = intervals[i];
                array[idx++] = new Interval(interval.start, -1);
                array[idx++] = new Interval(interval.end, 1);
            }

            Array.Sort(array, (x, y) =>
            {
                var r = x.start - y.start;
                return r == 0 ? x.end - y.end : r;
            });

            var list = new List<Interval>(cnt);

            for (int i = 1, start = array[0].start, pos = array[0].end; i < lcnt; i++)
            {
                pos += array[i].end;
                if (pos != 0) continue;

                list.Add(new Interval(start, array[i++].start));

                start = array[i].start;
                pos = array[i].end;
            }

            return list;
        }
    }
}
