
using LeetCode.Generics;

namespace LeetCode.P404
{

    public class Solution
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            return SumOfLeftLeaves(root, false);
        }

        public int SumOfLeftLeaves(TreeNode root, bool left)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return left ? root.val : 0;
            return SumOfLeftLeaves(root.left, true) + SumOfLeftLeaves(root.right, false);
        }
    }
}
