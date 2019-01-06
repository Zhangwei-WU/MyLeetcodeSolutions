
namespace LeetCode.P15
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);
            var len = nums.Length;
            if (len == 0 || nums[0] > 0 || nums[len - 1] < 0) return result;

            var rlen = 0;
            var mindex = -1;

            // compress, for non-zero values appear at most twice, zero appear only once if present
            for (int i = 0, prev = int.MaxValue, cnt = 0; i < len; i++)
            {
                var ni = nums[i];
                if (ni != prev)
                {
                    if (prev <= 0 && ni > 0) mindex = rlen - 1;

                    prev = ni;
                    cnt = 1;
                }
                else cnt++;

                if (ni == 0 && cnt == 3) result.Add(new int[] { 0, 0, 0 });
                if (ni == 0 && cnt > 1 || ni != 0 && cnt > 2) continue;
                nums[rlen++] = ni;
            }

            // now totalLength = rlen
            // [0, mindex] is neg or zero
            // [mindex + 1, rlen] is pos

            // neg + neg-zero == -pos
            if (rlen < 3 || mindex < 0) return result;
            for (int i = 0, pni = int.MaxValue, ni; i < mindex; i++)
            {
                if ((ni = nums[i]) == pni) continue; else pni = ni;
                for (int j = i + 1, k = rlen - 1, pnj = int.MaxValue, nj; j <= mindex && k != mindex; j++)
                {
                    if ((nj = nums[j]) == pnj) continue; else pnj = nj;
                    for (int nk = -(ni + nj), cp; k > mindex; k--)
                    {
                        if ((cp = nums[k] - nk) > 0) continue;
                        if (cp == 0) result.Add(new int[] { ni, nj, nk });
                        break;
                    }
                }
            }
            // -neg = pos + pos
            for (int i = mindex + 1, pni = int.MinValue, ni; i < rlen - 1; i++)
            {
                if ((ni = nums[i]) == pni) continue; else pni = ni;
                for (int j = i + 1, k = mindex, pnj = int.MinValue, nj; j < rlen && k != -1; j++)
                {
                    if ((nj = nums[j]) == pnj) continue; else pnj = nj;
                    for (int nk = -(ni + nj), cp; k >= 0; k--)
                    {
                        if ((cp = nums[k] - nk) > 0) continue;
                        if (cp == 0) result.Add(new int[] { nk, ni, nj });
                        break;
                    }
                }
            }

            return result;
        }
    }
}
