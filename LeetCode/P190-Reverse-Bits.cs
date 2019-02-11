

namespace LeetCode.P390
{
    public class Solution
    {
        public uint reverseBits(uint n)
        {
            uint r = 0;
            for (var i = 0; i < 32; ++i)
            {
                r <<= 1;
                if ((n & 1) == 1) r |= 1U;
                n >>= 1;
            }

            return r;
        }
    }
}
