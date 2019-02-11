using LeetCode.Generics;

namespace LeetCode.P297
{
    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return string.Empty;
            return root.val.ToString() + "," + serialize(root.left) + "," + serialize(root.right);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var numbers = data.Split(',');
            var pos = 0;
            return deserialize(numbers, ref pos);
        }

        public TreeNode deserialize(string[] data, ref int pos)
        {
            if (pos == data.Length) return null;

            var d = data[pos++];
            if (string.IsNullOrEmpty(d)) return null;

            var node = new TreeNode(int.Parse(d));
            node.left = deserialize(data, ref pos);
            node.right = deserialize(data, ref pos);

            return node;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
