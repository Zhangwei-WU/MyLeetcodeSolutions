namespace LeetCode.P829
{
    public class Solution
    {
        public int ConsecutiveNumbersSum(int N)
        {
            int cnt = 0;

            for (int i = 1; i < N; i++)
            {
                if ((N -= (i - 1)) % i == 0) cnt++;
            }

            return cnt;
        }
    }
}
