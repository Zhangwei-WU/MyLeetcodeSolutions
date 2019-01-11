namespace LeetCode.P41
{
    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            var len = nums.Length;
            for (var i = 0; i < len; i++) if (nums[i] <= 0 || nums[i] > len) nums[i] = int.MaxValue;
            for (var i = 0; i < len; i++)
            {
                int j = i, nj = nums[j];
                while (nj != int.MaxValue && nj != -1)
                {
                    j = nj - 1;
                    nj = nums[j];
                    nums[j] = -1;
                }
            }

            for (int i = 0; i < len; i++) if (nums[i] != -1) return i + 1;
            return nums.Length + 1;
        }
    }
}
