namespace LeetCode.P312
{
    public class Solution
    {
        public int MaxCoins(int[] nums)
        {
            var len = nums.Length;
            if (len == 0) return 0;
            if (len == 1) return nums[0];

            var cpy = new int[len + 2];
            for (var i = 0; i < len; i++) cpy[i + 1] = nums[i];
            cpy[0] = 1;
            cpy[len + 1] = 1;

            var dp = new int[len + 2, len + 2];

            for (var i = 1; i <= len; i++)
            {
                for (var left = 1; left <= len - i + 1; left++)
                {
                    var right = left + i - 1;
                    for (var j = left; j <= right; j++)
                    {
                        dp[left, right] = System.Math.Max(dp[left, right], cpy[left - 1] * cpy[j] * cpy[right + 1] + dp[left, j - 1] + dp[j + 1, right]);
                    }
                }
            }

            return dp[1, len];
        }
    }
}
