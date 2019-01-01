namespace LeetCode.P9
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;
            var y = x;
            long z = x % 10;
            if (z == 0) return false;

            while ((y /= 10) != 0) z = z * 10 + y % 10;

            return z == x;
        }
    }
}
