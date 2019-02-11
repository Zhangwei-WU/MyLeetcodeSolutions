using LeetCode.Generics;

namespace LeetCode.P236
{
    public class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode ans = null;
            Dfs(root, p, q, ref ans);
            return ans;
        }

        private bool Dfs(TreeNode root, TreeNode p, TreeNode q, ref TreeNode ans)
        {
            if (root == null || ans != null) return false;

            var curr = root == p || root == q;
            var left = Dfs(root.left, p, q, ref ans);
            var right = Dfs(root.right, p, q, ref ans);

            if (left && right || left && curr || right && curr) ans = root;

            return left || right || curr;
        }
    }
}
