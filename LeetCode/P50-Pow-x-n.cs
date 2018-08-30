/* Problem 50: Pow(x, n)
 * https://leetcode.com/problems/powx-n/description/
 * 
 * Implement pow(x, n).

 * Example 1:
 * Input: 2.00000, 10
 * Output: 1024.00000

 * Example 2:
 * Input: 2.10000, 3
 * Output: 9.26100
 */

namespace LeetCode.P50
{
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            if (n == 0 || x == 1.0d) return 1.0d;

            long ln = n;

            var negN = ln < 0;
            if (negN) ln = -ln;

            var negX = x < 0;
            if (negX) x = -x;
            var negS = negX && ln % 2 == 1;

            var v = 1.0d;

            for (var b = x; ln != 0L; ln >>= 1, b *= b)
            {
                if (ln % 2 == 1) v *= b;
                if (v == double.Epsilon || v == double.MaxValue) break;
            }

            return (negN ? 1 / v : v) * (negS ? -1.0d : 1.0d);
        }
    }
}
