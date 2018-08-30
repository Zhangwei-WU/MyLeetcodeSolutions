/* Problem 149. Max Points on a Line
 * https://leetcode.com/problems/max-points-on-a-line/description/
 * 
 * Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
 * 
 * AC: 159ms
 */

namespace LeetCode.P149
{
    public class Point
    {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }
    }
}

namespace LeetCode.P149
{
    public class Solution
    {
        public int MaxPoints(Point[] points)
        {
            var len = points.Length;
            if (len < 3) return len;
            
            var max = 0;
            for (var i = 0; i < len - max; i++)
            {
                var cnts = new System.Collections.Generic.Dictionary<double, int>();
                for (int j = i + 1, cmax = 0, dup = 0, x = points[i].x, y = points[i].y; j < len - max + cmax; j++)
                {
                    int dx = points[j].x - x, dy = points[j].y - y;
                    if (dx == 0 && dy == 0)
                    {
                        dup++;
                        cmax++;
                    }
                    else
                    {
                        var angle = dx == 0 ? double.MaxValue : dy * 100.0d / dx; // multiply 100.0 to avoid potential overflow
                        var cnt = 0;
                        if (!cnts.TryGetValue(angle, out cnt)) cnts.Add(angle, cnt = 1);
                        else cnts[angle] = ++cnt;
                        if (cnt + dup > cmax) cmax = cnt + dup;
                    }

                    if (cmax > max) max = cmax;
                }
            }

            return max + 1;
        }
    }
}
