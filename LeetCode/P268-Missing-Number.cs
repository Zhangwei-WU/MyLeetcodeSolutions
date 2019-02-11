
namespace LeetCode.P268
{
    public class Solution
    {
        public int MissingNumber(int[] nums)
        {
            var len = nums.Length;
            var sum = len * (len + 1) / 2;
            for (var i = 0; i < len; i++) sum -= nums[i];
            return sum;
        }
    }
}
