namespace LeetCode.P665
{
    public class Solution
    {
        public bool CheckPossibility(int[] nums)
        {
            var cnt = 0;
            for (var i = 0; i < nums.Length - 1; ++i)
            {
                if (nums[i] > nums[i + 1])
                {
                    if (i + 2 == nums.Length || nums[i + 2] >= nums[i]) nums[i + 1] = nums[i];
                    else if (i == 0 || nums[i + 1] >= nums[i - 1]) nums[i] = nums[i + 1];
                    else return false;

                    if (++cnt > 1) return false;
                }
            }

            return true;
        }
    }
}
