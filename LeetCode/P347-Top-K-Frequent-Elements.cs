
namespace LeetCode.P347
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            return nums.GroupBy(p => p).OrderByDescending(p => p.Count()).Take(k).Select(p => p.Key).ToArray();
            //Dictionary<int, int> counter = new Dictionary<int, int>();
            //for (int i = 0, len = nums.Length; i < len; i++)
            //{
            //    var n = nums[i];
            //    if (!counter.TryGetValue(n, out int c)) counter.Add(n, 1);
            //    else counter[n] = c + 1;
            //}

            //return counter.OrderByDescending(p => p.Value).Take(k).Select(p => p.Key).ToArray();
        }
    }
}
