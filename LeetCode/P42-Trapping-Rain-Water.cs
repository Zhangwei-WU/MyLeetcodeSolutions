/* Problem 42: Trapping Rain Water
 * https://leetcode.com/problems/trapping-rain-water/description/
 * 
 * Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.
 *
 * For example, 
 * Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.
 */

namespace LeetCode.P42
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            var len = height.Length;
            int[] maxls = new int[len];
            int[] maxrs = new int[len];

            int maxl = 0, maxr = 0;
            for (var i = 1; i < len; i++)
            {
                var l = height[i - 1];
                maxl = maxls[i] = l > maxl ? l : maxl;
                var r = height[len - i];
                maxr = maxrs[len - i - 1] = r > maxr ? r : maxr;
            }

            int total = 0;
            for (var i = 0; i < len; i++)
            {
                maxl = maxls[i];
                maxr = maxrs[i];

                var lr = (maxl < maxr ? maxl : maxr) - height[i];
                total += (lr > 0 ? lr : 0);
            }

            return total;
        }
    }
}
