
namespace LeetCode.P133
{
    using System.Collections.Generic;

    public class UndirectedGraphNode
    {
        public int label;
        public IList<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    };

    public class Solution
    {
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null) return null;
            var visited = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();
            Dfs(node, visited);

            foreach (var newNode in visited.Values)
            {
                for (var i = 0; i < newNode.neighbors.Count; i++)
                {
                    newNode.neighbors[i] = visited[newNode.neighbors[i]];
                }
            }

            return visited[node];
        }

        private void Dfs(UndirectedGraphNode node, Dictionary<UndirectedGraphNode, UndirectedGraphNode> visited)
        {
            if (visited.ContainsKey(node)) return;

            var newNode = new UndirectedGraphNode(node.label);
            foreach (var neighber in node.neighbors) newNode.neighbors.Add(neighber);

            visited.Add(node, newNode);
            foreach (var neignber in node.neighbors) Dfs(neignber, visited);
        }
    }
}
