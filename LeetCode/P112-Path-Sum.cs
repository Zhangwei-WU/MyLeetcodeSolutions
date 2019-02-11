/* Problem 112: Path Sum
 * https://leetcode.com/problems/path-sum/description/
 * 
 * Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
 * 
 * For example:
 * Given the below binary tree and sum = 22,
 *            5
 *           / \
 *          4   8
 *         /   / \
 *        11  13  4
 *       /  \      \
 *      7    2      1
 * return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.
 * 
 * AC: 169ms
 */


using LeetCode.Generics;

namespace LeetCode.P112
{
    public class Solution
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;

            return Visit(root, sum - root.val);
        }

        bool Visit(TreeNode node, int sum)
        {
            return node.left == null && node.right == null && sum == 0
                || node.left != null && Visit(node.left, sum - node.left.val)
                || node.right != null && Visit(node.right, sum - node.right.val);
        }
    }
}
