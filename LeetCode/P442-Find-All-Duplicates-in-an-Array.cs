
namespace LeetCode.P442
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            var result = new List<int>(nums.Length / 2);
            for (var i = 0; i < nums.Length; ++i)
            {
                for (int j = i, n = 0; nums[j] != j + 1; j = n - 1)
                {
                    var t = nums[j];
                    nums[j] = n;
                    n = t;

                    if (n == 0) break;

                    if (nums[n - 1] == n)
                    {
                        result.Add(n);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
