using LeetCode.Generics;

namespace LeetCode.P173
{
    using System.Collections.Generic;
    
    public class BSTIterator
    {
        IEnumerator<TreeNode> ienumerator = null;
        bool? next = null;

        public BSTIterator(TreeNode root)
        {
            ienumerator = Iterate(root).GetEnumerator();
        }

        /** @return the next smallest number */
        public int Next()
        {
            if (!next.HasValue) HasNext();
            next = null;
            return ienumerator.Current.val;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            if(!next.HasValue) next = ienumerator.MoveNext();
            return next.Value;
        }

        private IEnumerable<TreeNode> Iterate(TreeNode node)
        {
            if (node == null) yield break;
            foreach (var subNode in Iterate(node.left)) yield return subNode;
            yield return node;
            foreach (var subNode in Iterate(node.right)) yield return subNode;
        }
    }

    /**
     * Your BSTIterator object will be instantiated and called as such:
     * BSTIterator obj = new BSTIterator(root);
     * int param_1 = obj.Next();
     * bool param_2 = obj.HasNext();
     */
}
