
using LeetCode.Generics;

namespace LeetCode.P102
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));

            List<int> nodes = new List<int>();
            int level = 0;
            IList<IList<int>> result = new List<IList<int>>();

            while (queue.Count != 0)
            {
                var curr = queue.Dequeue();
                var node = curr.Key;
                var clevel = curr.Value;

                if(clevel != level)
                {
                    level = clevel;
                    result.Add(nodes);
                    nodes = new List<int>();
                }

                nodes.Add(node.val);
                if (node.left != null) queue.Enqueue(new KeyValuePair<TreeNode, int>(node.left, clevel + 1));
                if (node.right != null) queue.Enqueue(new KeyValuePair<TreeNode, int>(node.right, clevel + 1));
            }

            result.Add(nodes);
            return result;
        }
    }
}
