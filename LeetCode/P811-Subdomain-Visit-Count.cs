
namespace LeetCode.P811
{
    using System.Collections.Generic;

    public class Solution
    {
        private class TrieNode
        {
            public TrieNode()
            {
                Count = 0;
                Sub = new Dictionary<string, TrieNode>();
            }

            public int Count;
            public Dictionary<string, TrieNode> Sub;
        }

        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            TrieNode root = new TrieNode();
            foreach (var domain in cpdomains)
            {
                var idx = domain.IndexOf(' ');
                var cnt = int.Parse(domain.Substring(0, idx));
                var parts = domain.Substring(idx + 1).Split('.');

                var p = root;
                for (int len = parts.Length, i = len - 1; i >= 0; --i)
                {
                    var part = parts[i];
                    if (!p.Sub.TryGetValue(part, out TrieNode sub))
                        p.Sub.Add(part, sub = new TrieNode());
                    sub.Count += cnt;
                    p = sub;
                }
            }

            return new List<string>(GetResult(root, string.Empty));
        }

        private IEnumerable<string> GetResult(TrieNode root, string prefix)
        {
            var first = string.IsNullOrEmpty(prefix);
            foreach (var sub in root.Sub)
            {
                var n = first ? sub.Key : sub.Key + "." + prefix;
                yield return sub.Value.Count.ToString() + " " + n;
                foreach (var result in GetResult(sub.Value, n)) yield return result;
            }
        }
    }
}
