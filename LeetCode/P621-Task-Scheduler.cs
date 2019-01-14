namespace LeetCode.P621
{
    using System;
    public class Solution
    {
        public int LeastInterval(char[] tasks, int n)
        {
            var counters = new int[26];
            for (int i = 0, len = tasks.Length; i < len; i++) counters[tasks[i] - 'A']++;
            Array.Sort(counters, (a, b) => b - a);
            int max = counters[0] - 1, idle = max * n;
            for (var i = 1; i < 26 && counters[i] != 0; i++) idle -= Math.Min(counters[i], max);
            return idle > 0 ? idle + tasks.Length : tasks.Length;
        }
    }
}
