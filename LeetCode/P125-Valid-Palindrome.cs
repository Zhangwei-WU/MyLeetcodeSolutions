
namespace LeetCode
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            for (int l = 0, r = s.Length - 1, cl = 0, cr = 0; l < r; ++l, --r)
            {
                while (l < r
                    && ((cl = s[l]) < 48
                    || cl > 57 && cl < 65
                    || cl > 90 && cl < 97
                    || cl > 122)) ++l;
                while (r > l
                    && ((cr = s[r]) < 48
                    || cr > 57 && cr < 65
                    || cr > 90 && cr < 97
                    || cr > 122)) --r;

                if (l == r) return true;

                if (cl >= 97 && cl <= 122) cl -= 32;
                if (cr >= 97 && cr <= 122) cr -= 32;
                if (cl != cr) return false;
            }

            return true;
        }
    }
}
