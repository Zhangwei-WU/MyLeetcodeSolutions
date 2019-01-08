namespace LeetCode.P53
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            var maxsum = nums[0];
            for (int i = 1, subtotal = maxsum, len = nums.Length; i < len; i++)
            {
                if (subtotal < 0) subtotal = nums[i];
                else subtotal += nums[i];
                if (subtotal > maxsum) maxsum = subtotal;
            }

            return maxsum;
        }
    }
}
