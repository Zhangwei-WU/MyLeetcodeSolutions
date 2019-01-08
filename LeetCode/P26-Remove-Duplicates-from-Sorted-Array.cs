
namespace LeetCode.P26
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            var len = nums.Length;
            if (len < 2) return len;

            var nlen = 1;
            for (int i = 1, prev = nums[0], curr; i < len; i++)
            {
                if ((curr = nums[i]) != prev) prev = nums[nlen++] = curr;
            }

            return nlen;
        }
    }
}
