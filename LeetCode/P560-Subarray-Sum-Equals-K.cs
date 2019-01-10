namespace LeetCode.P560
{
    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            var len = nums.Length;
            if (len == 0) return 0;

            for (int i = 1, prev = nums[0]; i < len; i++) prev = nums[i] += prev;

            int total = 0;

            for (var i = 0; i < len; i++)
            {
                var ni = nums[i];
                if (ni == k) total++;
                for (var j = i + 1; j < len; j++)
                {
                    if (nums[j] - ni == k) total++;
                }
            }

            return total;
        }
    }
}
