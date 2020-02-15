
namespace LeetCode.P982
{
    using System.Collections.Generic;

    public class Solution
    {
        public int CountTriplets(int[] A)
        {
            var l = A.Length;
            var c = new Dictionary<int, int>();
            var n = 0;

            // i, j, [k]
            for (var i = 0; i < l; ++i)
            {
                for (var j = 0; j < l; ++j)
                {
                    var a = A[i] & A[j];
                    if (!c.TryGetValue(a, out int cnt))
                    {
                        for (var k = 0; k < l; ++k) cnt += (a & A[k]) == 0 ? 1 : 0;
                        c.Add(a, cnt);
                    }

                    n += cnt;
                }
            }

            return n;
        }
    }
}
