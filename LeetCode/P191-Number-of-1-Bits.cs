
namespace LeetCode.P191
{
    public class Solution
    {
        public int HammingWeight(uint n)
        {
            var c = 0;
            for (; n != 0U; n >>= 1) if ((n & 1) == 1U) c++;
            return c;
        }
    }
}
