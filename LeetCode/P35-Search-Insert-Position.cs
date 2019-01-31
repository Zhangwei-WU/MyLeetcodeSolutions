namespace LeetCode.P35
{
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            var pos = System.Array.BinarySearch(nums, target);
            return pos < 0 ? ~pos : pos;
        }
    }
}
