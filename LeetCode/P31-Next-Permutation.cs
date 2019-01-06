
namespace LeetCode.P31
{
    public class Solution
    {
        public void NextPermutation(int[] nums)
        {
            var len = nums.Length;
            var i = len - 1;
            for (; i > 0 && nums[i - 1] >= nums[i]; i--) ;

            if (i != 0)
            {
                int j = len - 1, n = nums[i - 1];
                for (; j >= 0 && n >= nums[j]; j--) ;
                nums[i - 1] = nums[j];
                nums[j] = n;
            }

            for (int mid = i + (len - i) / 2, j = len - 1; i < mid; i++, j--)
            {
                var t = nums[i];
                nums[i] = nums[j];
                nums[j] = t;
            }

            return;
        }
    }
}
