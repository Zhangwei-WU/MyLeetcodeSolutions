namespace LeetCode.P84
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int LargestRectangleArea(int[] heights)
        {
            var len = heights.Length;
            if (len == 0) return 0;
            var ck = new bool[len];
            var mins = new int[len];
            var maxs = new int[len];
            var heightsWithIndex = new KeyValuePair<int, int>[len];
            for (var i = 0; i < len; i++)
            {
                mins[i] = i;
                maxs[i] = i;
                heightsWithIndex[i] = new KeyValuePair<int, int>(heights[i], i);
            }

            Array.Sort(heightsWithIndex, (a, b) => b.Key - a.Key);

            var area = int.MinValue;
            for (int i = 0, j; i < len; i = j)
            {
                int idxi = heightsWithIndex[i].Value, idxj;
                for (j = i; j < len && idxi == (idxj = heightsWithIndex[j].Value); j++)
                {
                    var checkLeft = idxj > 0 && ck[idxj - 1];
                    var checkRight = idxj < len - 1 && ck[idxj + 1];
                    if ( checkLeft && checkRight)
                    {
                        mins[idxj] = mins[idxj + 1] = mins[idxj - 1];
                        maxs[idxj] = maxs[idxj - 1] = maxs[idxj + 1];
                    }
                    else if (checkLeft)
                    {
                        mins[idxj] = mins[idxj - 1];
                        maxs[idxj - 1] = maxs[idxj];
                    }
                    else if (checkRight)
                    {
                        mins[idxj + 1] = mins[idxj];
                        maxs[idxj] = maxs[idxj + 1];
                    }

                    ck[idxj] = true;
                }

                for (int k = i, min = -1, max = -1; k < j; k++)
                {
                    var c = heightsWithIndex[k].Value;
                    if (min <= c && max >= c) continue;
                    min = max = c;
                    int tmin, tmax;
                    while ((tmin = mins[min]) != min) { mins[min] = mins[tmin]; min = tmin; }
                    while ((tmax = maxs[max]) != max) { maxs[max] = maxs[tmax]; max = tmax; }
                    
                    var t = (max - min + 1) * heightsWithIndex[k].Key;
                    if (t > area) area = t;
                }
            }

            return area;
        }
    }
}
