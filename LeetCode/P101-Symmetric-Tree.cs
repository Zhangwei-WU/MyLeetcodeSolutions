using LeetCode.Generics;

namespace LeetCode.P101
{
    public class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root, root);
        }

        private bool IsSymmetric(TreeNode l, TreeNode r)
        {
            if (l == null && r == null) return true;
            if (l == null || r == null) return false;
            if (l.val != r.val) return false;
            if (!IsSymmetric(l.left, r.right)) return false;
            if (!IsSymmetric(l.right, r.left)) return false;
            return true;
        }
    }
}
