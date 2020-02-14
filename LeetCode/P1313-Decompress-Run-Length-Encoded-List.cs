
namespace LeetCode.P1313
{
    public class Solution
    {
        public int[] DecompressRLElist(int[] nums)
        {
            var l = 0;
            for (var i = 0; i < nums.Length; i += 2) l += nums[i];
            var result = new int[l];
            l = 0;

            for (var i = 0; i < nums.Length; i += 2)
            {
                var a = nums[i];
                var b = nums[i + 1];
                for (var j = 0; j < a; ++j)
                {
                    result[l++] = b;
                }
            }

            return result;
        }
    }
}
