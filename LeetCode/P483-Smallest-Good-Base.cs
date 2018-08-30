/* Problem 483. Smallest Good Base
 * https://leetcode.com/problems/smallest-good-base/description/
 * 
 * For an integer n, we call k>=2 a good base of n, if all digits of n base k are 1.
 * Now given a string representing n, you should return the smallest good base of n in string format. 
 * 
 * Example 1:
 * Input: "13"
 * Output: "3"
 * Explanation: 13 base 3 is 111.
 * 
 * Example 2:
 * Input: "4681"
 * Output: "8"
 * Explanation: 4681 base 8 is 11111.
 * 
 * Example 3:
 * Input: "1000000000000000000"
 * Output: "999999999999999999"
 * Explanation: 1000000000000000000 base 999999999999999999 is 11.
 * 
 * Note:
 * The range of n is [3, 10^18].
 * The string representing n is always valid and will not have leading zeros.
 */

namespace LeetCode.P483
{
    public class Solution
    {
        public string SmallestGoodBase(string n)
        {
            var ln = long.Parse(n) - 1;
            for (var i = 62; i > 1; i--)
            {
                if (ln < (1L << i)) continue;

                var max = (long)System.Math.Exp(1.0 / i * System.Math.Log(ln));
                var min = (long)System.Math.Ceiling(System.Math.Exp(1.0 / i * System.Math.Log(ln / 2)));

                while (min <= max)
                { 
                    var mid = min + ((max - min) >> 1);
                    var overflowed = false;
                    for (long k = 0, b = mid, r = b - ln; k++ < i; b *= mid, r += b)
                    {
                        if (r == 0) return mid.ToString();
                        else if (r > 0)
                        {
                            overflowed = true;
                            break;
                        }
                    }

                    if (overflowed) max = mid - 1;
                    else min = mid + 1;
                }
            }

            return ln.ToString();
        }
    }
}
