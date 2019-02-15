
namespace LeetCode.P18
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var len = nums.Length;
            if (len < 4) return new List<IList<int>>();

            Array.Sort(nums);
            // compress,for !0 appear at most 3 times, 0 appear at most 4 times
            var nlen = 1;
            for (int i = 1, c = nums[0], n = 1; i < len; ++i)
            {
                var v = nums[i];
                if (v != c || ++n <= 4) nums[nlen++] = v;
                if (v != c) { c = v; n = 1; }
            }

            var result = new List<IList<int>>();
            for (int i = 0, ni, nj, nk, nl; i < nlen - 3; ++i)
            {
                ni = nums[i];
                if (i > 0 && ni == nums[i - 1]) continue;
                if (ni + nums[i + 1] + nums[i + 2] + nums[i + 3] > target) break;
                for (int j = i + 1, ti = target - ni; j < nlen - 2; ++j)
                {
                    nj = nums[j];
                    if (j > i + 1 && nj == nums[j - 1]) continue;
                    if (nj + nums[j + 1] + nums[j + 2] > ti) break;
                    for (int k = j + 1, tj = ti - nj; k < nlen - 1; ++k)
                    {
                        nk = nums[k];
                        if (k > j + 1 && nk == nums[k - 1]) continue;
                        if (nk + nums[k + 1] > tj) break;
                        var idx = Array.BinarySearch(nums, k + 1, nlen - k - 1, tj - nk);
                        if (idx < 0) continue;
                        result.Add(new int[] { ni, nj, nk, nums[idx] });
                    }
                }
            }

            return result;
        }
    }
}
