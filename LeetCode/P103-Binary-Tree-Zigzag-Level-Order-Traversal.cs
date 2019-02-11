using LeetCode.Generics;

namespace LeetCode.P103
{
    using System.Collections.Generic;
    
    public class Solution
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            Dfs(root, 0, result);
            for (var i = 1; i < result.Count; i += 2)
            {
                var zag = result[i];
                for (int j = 0, cnt = zag.Count; j < cnt / 2; j++)
                {
                    var t = zag[j];
                    zag[j] = zag[cnt - 1 - j];
                    zag[cnt - 1 - j] = t;
                }
            }

            return result;
        }

        private void Dfs(TreeNode root, int level, IList<IList<int>> result)
        {
            if (root == null) return;
            if (result.Count < level + 1) result.Add(new List<int>());
            result[level].Add(root.val);

            Dfs(root.left, level + 1, result);
            Dfs(root.right, level + 1, result);
        }
    }
}
