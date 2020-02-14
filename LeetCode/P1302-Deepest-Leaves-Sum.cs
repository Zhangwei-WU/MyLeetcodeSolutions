
using LeetCode.Generics;

namespace LeetCode.P1302
{
    using System.Collections.Generic;
    public class Solution
    {
        public int DeepestLeavesSum(TreeNode root)
        {
            return DeepestLeavesSum(root, 0).Value;
        }

        private KeyValuePair<int, int> DeepestLeavesSum(TreeNode root, int depth)
        {
            ++depth;
            if (root == null) return new KeyValuePair<int, int>(depth, 0);
            if (root.left == null && root.right == null) return new KeyValuePair<int, int>(depth, root.val);
            var left = DeepestLeavesSum(root.left, depth);
            var right = DeepestLeavesSum(root.right, depth);

            if (left.Key == right.Key) return new KeyValuePair<int, int>(left.Key, left.Value + right.Value);
            else if (left.Key > right.Key) return left;
            else return right;
        }
    }
}
