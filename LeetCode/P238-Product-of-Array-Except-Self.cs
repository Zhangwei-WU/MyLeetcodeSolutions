namespace LeetCode.P238
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var len = nums.Length;
            var result = new int[len];
            result[0] = 1;

            for (var i = 1; i < len; i++) result[i] = nums[i - 1] * result[i - 1];
            var temp = result[len - 1];
            result[len - 1] = 1;
            for (var i = len - 2; i >= 0; i--)
            {
                var temp2 = result[i];
                result[i] = nums[i + 1] * result[i + 1];
                result[i + 1] *= temp;
                temp = temp2;
            }

            return result;
        }
    }
}
