using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            var curr = int.MinValue;
            var first = true;
            foreach(var node in Iterate(root))
            {
                if (!first && node.val <= curr) return false;
                first = false;
                curr = node.val;
            }

            return true;
        }

        private IEnumerable<TreeNode> Iterate(TreeNode node)
        {
            if (node == null) yield break;
            foreach (var subNode in Iterate(node.left)) yield return subNode;
            yield return node;
            foreach (var subNode in Iterate(node.right)) yield return subNode;
        }
    }
}
