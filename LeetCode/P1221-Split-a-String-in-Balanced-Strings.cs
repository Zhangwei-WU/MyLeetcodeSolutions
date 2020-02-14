namespace LeetCode.P1221
{

    public class Solution
    {
        public int BalancedStringSplit(string s)
        {
            var n = 0;
            var r = 0;
            foreach(var c in s)
            {
                if (c == 'L') --n;
                else if (c == 'R') ++n;

                if (n == 0) ++r;
            }

            return r;
        }
    }
}
