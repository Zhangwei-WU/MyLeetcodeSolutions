namespace LeetCode.P389
{

    public class Solution
    {
        public char FindTheDifference(string s, string t)
        {
            int n = 0;
            foreach(var c in s) n ^= (int)c;
            foreach (var c in t) n ^= (int)c;
            return (char)n;
        }
    }
}
