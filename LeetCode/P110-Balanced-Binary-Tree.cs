
using LeetCode.Generics;

namespace LeetCode.P110
{
    public class Solution
    {
        public bool IsBalanced(TreeNode root)
        {
            int depth = 0;
            return IsBalanced(root, out depth);
        }

        private bool IsBalanced(TreeNode root, out int depth)
        {
            depth = 0;
            return root == null
                || (IsBalanced(root.left, out int dl)
                && IsBalanced(root.right, out int dr)
                && (depth = System.Math.Max(dl, dr) + 1) <= System.Math.Min(dl, dr) + 2);
        }
    }
}
