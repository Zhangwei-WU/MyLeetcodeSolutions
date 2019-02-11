using LeetCode.Generics;

namespace LeetCode.P124
{
    public class Solution
    {
        public int MaxPathSum(TreeNode root)
        {
            int global = int.MinValue;
            Max(root, ref global);
            return global;
        }

        // key is node+left?/right?, value is node+left?+right?
        private int Max(TreeNode root, ref int global)
        {
            if (root == null) return 0;

            var lbranch = Max(root.left, ref global);
            var rbranch = Max(root.right, ref global);
            
            var tglobal = root.val + lbranch + rbranch;
            if (tglobal > global) global = tglobal;

            var branch = root.val + (lbranch > rbranch ? lbranch : rbranch);
            return branch < 0 ? 0 : branch;

        }
    }
}
