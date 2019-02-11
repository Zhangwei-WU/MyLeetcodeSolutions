

namespace LeetCode.P367
{
    public class Solution
    {
        public bool IsPerfectSquare(int num)
        {
            if (num <= 0) return false;
            for (long i = 1L, s; (s = i * i) <= num; i++) if (s == num) return true;
            return false;
        }
    }
}
