
using LeetCode.Generics;

namespace LeetCode.P105
{
    public class Solution
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var index = 0;
            return BuildTree(preorder, inorder, ref index, 0, inorder.Length, inorder.Length);
        }

        private TreeNode BuildTree(int[] preorder, int[] inorder, ref int preIndex, int inIndex1, int inIndex2, int length)
        {
            if (preIndex >= length) return null;

            var val = preorder[preIndex];

            var index = -1;
            for (var i = inIndex1; i < inIndex2; ++i)
            {
                if (inorder[i] != val) continue;
                index = i;
                break;
            }

            if (index < 0) return null;

            ++preIndex;
            var node = new TreeNode(val);

            node.left = BuildTree(preorder, inorder, ref preIndex, inIndex1, index, length);
            node.right = BuildTree(preorder, inorder, ref preIndex, index + 1, inIndex2, length);
            return node;
        }
    }
}
