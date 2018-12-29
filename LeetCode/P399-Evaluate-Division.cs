
namespace LeetCode.P399
{
    using System.Collections.Generic;

    public class Solution
    {
        public double[] CalcEquation(string[,] equations, double[] values, string[,] queries)
        {
            var zeros = new HashSet<string>();
            var graph = new Graph();

            var len = values.Length;

            for (var i = 0; i < len; i++)
            {
                var val = values[i];
                if (val == 0.0d)
                {
                    zeros.Add(equations[i, 0]);
                    continue;
                }

                graph.AddEdge(equations[i, 0], equations[i, 1], val);
                graph.AddEdge(equations[i, 1], equations[i, 0], 1.0d / val);
            }

            len = queries.GetLength(0);
            var result = new double[len];

            for (var i = 0; i < len; i++)
            {
                if (zeros.Contains(queries[i, 0]))
                {
                    result[i] = 0.0d;
                    continue;
                }
                
                var path = graph.FindPath(queries[i, 0], queries[i, 1]);
                if (path == null || path.Length == 0)
                {
                    result[i] = -1.0d;
                    continue;
                }

                var r = 1.0d;
                for (var j = 0; j < path.Length; j++) r *= path[j];
                result[i] = r;
            }

            return result;
        }

        private class Graph
        {
            private Dictionary<string, Dictionary<string, double>> g = new Dictionary<string, Dictionary<string, double>>();

            public bool AddEdge(string v1, string v2, double v)
            {
                if (!g.TryGetValue(v1, out Dictionary<string, double> adj))
                {
                    adj = new Dictionary<string, double>();
                    g.Add(v1, adj);
                }

                if (adj.ContainsKey(v2)) return false;
                adj.Add(v2, v);
                return true;
            }

            public double[] FindPath(string v1, string v2)
            {
                if (!g.ContainsKey(v1) || !g.ContainsKey(v2)) return null;
                if (v1 == v2) return new double[] { 1.0d };

                HashSet<string> visited = new HashSet<string>(g.Count);
                visited.Add(v1);

                List<double> path = new List<double>(g.Count);

                if (TravelPath(v1, v2, visited, path)) return path.ToArray();

                return null;
            }

            private bool TravelPath(string v1, string v2, HashSet<string> visited, List<double> path)
            {
                g.TryGetValue(v1, out Dictionary<string, double> adj);
                if (adj.TryGetValue(v2, out double v))
                {
                    path.Add(v);
                    return true;
                }
                
                foreach (var kv in adj)
                {
                    if (!visited.Add(kv.Key)) continue;

                    if (TravelPath(kv.Key, v2, visited, path))
                    {
                        path.Add(kv.Value);
                        return true;
                    }

                    visited.Remove(kv.Key);
                }

                return false;
            }
        }
    }
}
