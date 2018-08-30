/* Problem 134: Gas Station
 * https://leetcode.com/problems/gas-station/description/
 * 
 * There are N gas stations along a circular route, where the amount of gas at station i is gas[i].
 * You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station (i+1). You begin the journey with an empty tank at one of the gas stations.
 * Return the starting gas station's index if you can travel around the circuit once, otherwise return -1.

 * Note:
 * The solution is guaranteed to be unique.
 */

namespace LeetCode.P134
{
    public class Solution
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var len = gas.Length;

            var i = 0;
            var j = i;

            var sum = gas[i] - cost[i];

            while (true)
            {
                while (sum < 0)
                {
                    if (--i == -1) i += len;
                    if (i == j) return -1;

                    sum += gas[i] - cost[i];
                }

                while (sum >= 0)
                {
                    if (++j == len) j -= len;
                    if (i == j) return i;

                    sum += gas[j] - cost[j];
                }
            }
        }
    }
}
