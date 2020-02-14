
using LeetCode.Generics;
using System.Collections.Generic;

namespace LeetCode.P654
{
    public class Solution
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return ConstructMaximumBinaryTree(nums, 0, nums.Length);
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums, int startIndex, int length)
        {
            if (length == 0) return null;

            int maxIndex = startIndex;
            int maxValue = nums[startIndex];
            for (var i = startIndex + 1; i < startIndex + length; ++i)
            {
                if (nums[i] > maxValue) maxValue = nums[maxIndex = i];
            }

            var node = new TreeNode(maxValue);
            node.left = ConstructMaximumBinaryTree(nums, startIndex, maxIndex - startIndex);
            node.right = ConstructMaximumBinaryTree(nums, maxIndex + 1, startIndex + length - maxIndex - 1);

            return node;
        }
    }
}


// O(n) approach?