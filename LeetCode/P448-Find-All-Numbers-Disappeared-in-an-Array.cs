namespace LeetCode.P448
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            for (var i = 0; i < nums.Length; ++i)
            {
                for (int j = i, n = 0; nums[j] != j + 1; j = n - 1)
                {
                    var t = nums[j];
                    nums[j] = n;
                    n = t;

                    if (n == 0 || nums[n - 1] == n) break;
                }
            }

            var result = new List<int>(nums.Length / 2);

            for (var i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != i + 1) result.Add(i + 1);
            }
            return result;

        }
    }
}
