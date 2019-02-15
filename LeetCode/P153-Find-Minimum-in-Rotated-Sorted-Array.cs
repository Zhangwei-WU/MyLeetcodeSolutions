
namespace LeetCode.P153
{
    public class Solution
    {
        public int FindMin(int[] nums)
        {
            int l = 0, h = nums.Length - 1;
            if (h == 0 || nums[h] > nums[l]) return nums[l];
            while (l < h)
            {
                var m = l + (h - l) / 2;
                if (nums[m] > nums[h]) l = m + 1;
                else h = m;
            }

            return nums[h];
        }
    }
}
