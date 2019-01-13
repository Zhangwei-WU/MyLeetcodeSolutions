namespace LeetCode.P46
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var len = nums.Length;
            var total = 1;
            for (var i = 2; i <= len; i++) total *= i;
            var result = new List<IList<int>>(total);
            Recursive(nums, 0, nums.Length, result);
            return result;
        }

        private void Recursive(int[] nums, int index, int length, IList<IList<int>> result)
        {
            if (index == length)
            {
                var copy = new int[length];
                for (var i = 0; i < length; i++) copy[i] = nums[i];
                result.Add(copy);
                return;
            }

            for (int i = index; i < length; i++)
            {
                var t = nums[index];
                nums[index] = nums[i];
                nums[i] = t;

                Recursive(nums, index + 1, length, result);

                nums[i] = nums[index];
                nums[index] = t;
            }
        }
    }
}
