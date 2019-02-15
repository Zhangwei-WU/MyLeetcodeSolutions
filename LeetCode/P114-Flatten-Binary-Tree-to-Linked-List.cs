using LeetCode.Generics;

namespace LeetCode.P114
{
    public class Solution
    {
        public void Flatten(TreeNode root)
        {
            Flatten2(root);
        }

        /// <summary>
        /// return last node of current tree
        /// </summary>
        private TreeNode Flatten2(TreeNode root)
        {
            if (root == null) return null;
            var left = Flatten2(root.left);
            var right = Flatten2(root.right);

            if (left == null && right == null) return root;
            else if (left == null) return right;
            else if (right == null)
            {
                root.right = root.left;
                root.left = null;
                return left;
            }
            else
            {
                left.right = root.right;
                root.right = root.left;
                root.left = null;
                return right;
            }
        }
    }
}
