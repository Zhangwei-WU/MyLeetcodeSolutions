namespace LeetCode.P27
{
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            var len = nums.Length;
            var rlen = 0;
            for (var i = 0; i < len; i++)
            {
                var n = nums[i];
                if(val != n) nums[rlen++] = n;
            }

            return rlen;
        }
    }
}
