/// <summary>
/// S1 looks like stupid but faster: 112ms
/// S2 is really neat however slower: 116ms
/// </summary>

namespace LeetCode.P128.S1
{
    using System.Collections.Generic;

    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            var len = nums.Length;
            Dictionary<int, int> p = new Dictionary<int, int>(len);
            for (var i = 0; i < len; i++) p[nums[i]] = i;
            
            int[] next = new int[len];

            for (var i = 0; i < len; i++) next[i] = p.TryGetValue(nums[i] + 1, out int pos) ? pos : -1;

            int result = 0;
            for (var i = 0; i < len; i++)
            {
                if (p.ContainsKey(nums[i] - 1)) continue;
                int cnt = 1, j = i;
                while ((j = next[j]) != -1) cnt++;

                if (cnt > result) result = cnt;
            }

            return result;
        }
    }
}


namespace LeetCode.P128.S2
{
    using System.Collections.Generic;

    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            var set = new HashSet<int>(nums);

            int result = 0;
            for (int i = 0, len = nums.Length; i < len; i++)
            {
                var n = nums[i];
                if (set.Contains(n - 1)) continue;
                var cnt = 1;
                while (set.Contains(++n)) cnt++;
                if (cnt > result) result = cnt;
            }

            return result;
        }
    }
}
