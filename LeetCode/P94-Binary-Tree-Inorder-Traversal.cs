namespace LeetCode
{
    using System.Collections.Generic;
    using System.Linq;


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            return Rec(root).ToArray();
        }

        private IEnumerable<int> Rec(TreeNode root)
        {
            if (root == null) yield break;

            foreach (var n in Rec(root.left)) yield return n;
            yield return root.val;
            foreach (var n in Rec(root.right)) yield return n;
        }
    }
}
