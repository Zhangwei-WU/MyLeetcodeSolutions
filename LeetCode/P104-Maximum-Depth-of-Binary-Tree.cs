
using LeetCode.Generics;

namespace LeetCode.P104
{
    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return System.Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
    }
}