
namespace LeetCode.P75
{
    public class Solution
    {
        public void SortColors(int[] nums)
        {
            for (int l = 0, r = nums.Length - 1, i = 0; i <= r;)
            {
                var n = nums[i];
                if (n == 0 && i == l) l = ++i;
                else if (n == 1) ++i;
                else if (n == 0)
                {
                    nums[i] = nums[l];
                    nums[l++] = 0;
                }
                else // n == 2
                {
                    nums[i] = nums[r];
                    nums[r--] = 2;
                }
            }
        }
    }
}
