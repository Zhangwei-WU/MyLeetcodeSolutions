namespace LeetCode.P1342
{
    public class Solution
    {
        public int NumberOfSteps(int num)
        {
            if (num == 0) return 0;

            var step = 1;
            while ((num = ((num & 1) == 1) ? num - 1 : (num >> 1)) != 0) step++;
            return step;
        }
    }
}
