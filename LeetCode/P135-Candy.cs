/* Problem 135. Candy
 * https://leetcode.com/problems/candy/description/
 * 
 * There are N children standing in a line. Each child is assigned a rating value.
 * You are giving candies to these children subjected to the following requirements:
 *  - Each child must have at least one candy.
 *  - Children with a higher rating get more candies than their neighbors.
 * What is the minimum candies you must give?
 * 
 * AC: 202ms
 */

namespace LeetCode.P135
{
    public class Solution
    {
        public int Candy(int[] ratings)
        {
            var len = ratings.Length;
            if (len < 2) return len;

            int[] candies = new int[len];

            candies[0] = 1;
            for (var i = 1; i < len; i++)
            {
                candies[i] = ratings[i] > ratings[i - 1] ? candies[i - 1] + 1 : 1;
            }

            var total = candies[len - 1];
            for (var i = len - 1; i > 0; i--)
            {
                var c = candies[i - 1];
                if (ratings[i - 1] > ratings[i])
                {
                    var ci = candies[i];
                    if (c <= ci)
                        c = candies[i - 1] = ci + 1;
                }

                total += c;
            }
            
            return total;
        }
    }
}
