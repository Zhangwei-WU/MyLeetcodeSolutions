namespace LeetCode.P393
{
    public class Solution
    {
        public bool ValidUtf8(int[] data)
        {
            for (int i = 0, len = data.Length; i < len;)
            {
                var c = data[i++];

                c >>= 3;
                if(c == 0x1E)
                {
                    if (i + 3 > len) return false;
                    if (data[i++] >> 6 != 0x2 || data[i++] >> 6 != 0x2 || data[i++] >> 6 != 0x2) return false;
                    continue;
                }

                c >>= 1;
                if(c == 0x0E)
                {
                    if (i + 2 > len) return false;
                    if (data[i++] >> 6 != 0x2 || data[i++] >> 6 != 0x2) return false;
                    continue;
                }

                c >>= 1;
                if (c == 0x6)
                {
                    if (i + 1 > len) return false;
                    if (data[i++] >> 6 != 0x2) return false;
                    continue;
                }

                c >>= 2;
                if (c == 0x0) continue;

                return false;
            }

            return true;
        }
    }
}
