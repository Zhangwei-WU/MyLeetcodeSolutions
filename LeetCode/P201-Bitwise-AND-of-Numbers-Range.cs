
namespace LeetCode.P201
{
    public class Solution
    {
        public int RangeBitwiseAnd(int m, int n)
        {
            var result = m;
            var shift = 0;
            while (result != 0 & m < n)
            {
                while ((result & 1) == 0)
                {
                    result >>= 1;
                    m >>= 1;
                    n >>= 1;
                    shift++;
                }

                result &= m++;
            }

            return (result & n) << shift;
        }
    }
}
