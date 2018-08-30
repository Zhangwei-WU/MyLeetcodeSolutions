/* Problem 97. Interleaving String
 * https://leetcode.com/problems/interleaving-string/description/
 * 
 * Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.
 * 
 * For example,
 * Given:
 * s1 = "aabcc",
 * s2 = "dbbca",
 * When s3 = "aadbbcbcac", return true.
 * When s3 = "aadbbbaccc", return false.
 * 
 */

namespace LeetCode.P97
{
    public class Solution
    {
        private string s1;
        private string s2;
        private string s3;
        private System.Collections.Generic.HashSet<int> traps = new System.Collections.Generic.HashSet<int>();

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;

            this.traps.Clear();
            return IsInterleave(0, 0);
        }

        private bool IsInterleave(int s1pos, int s2pos)
        {
            var s3pos = s1pos + s2pos;
            if (s3pos == s3.Length) return true;
            else if (traps.Contains(s1pos << 16 | s2pos)) return false;
            else if (s1pos < s1.Length && s3[s3pos] == s1[s1pos] && IsInterleave(s1pos + 1, s2pos)) return true;
            else if (s2pos < s2.Length && s3[s3pos] == s2[s2pos] && IsInterleave(s1pos, s2pos + 1)) return true;
            else return !traps.Add(s1pos << 16 | s2pos);
        }
    }
}
