namespace LeetCode.P30
{
    using System.Collections.Generic;

    public class Solution
    {
        private class TrieNode
        {
            public TrieNode(char c)
            {
                subNodes = new Dictionary<char, TrieNode>();
                indices = new List<int>();
            }

            public Dictionary<char, TrieNode> subNodes;
            public List<int> indices;
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            var alen = words.Length;

            if (alen == 0) return new int[] { };

            var trie = BuildTrie(words);

            var chars = s.ToCharArray();
            var clen = chars.Length;
            var wlen = words[0].Length;

            var indices = new List<KeyValuePair<int, List<int>>>();
            for (int i = 0, j; i < clen; i++)
            {
                var p = trie;
                for (j = 0; j < wlen && i + j < clen; j++)
                {
                    if (!p.subNodes.TryGetValue(chars[i + j], out p)) break;
                }

                if (j != wlen) continue;
                indices.Add(new KeyValuePair<int, List<int>>(i, p.indices));
            }
            
            var result = new List<int>();

            for (int i = 0, ilen = indices.Count, endl = ilen - alen + 1; i < endl; i++)
            {
                var curr = indices[i].Key;

                bool[] removed = new bool[alen];

                var matched = 0;
                for (var j = i; matched != alen && j < endl + matched; j++)
                {
                    var c = indices[j];
                    var cp = c.Key - curr;
                    if (cp == 0)
                    {
                        foreach (var index in c.Value)
                        {
                            if (removed[index]) continue;
                            matched++;
                            curr += wlen;
                            removed[index] = true;
                            break;
                        }
                    }
                    else if (cp > 0) break;
                }

                if (matched == alen) result.Add(indices[i].Key);
            }

            return result.ToArray();
        }

        private TrieNode BuildTrie(string[] words)
        {
            TrieNode root = new TrieNode('\0');
            for (var i = 0; i < words.Length; ++i)
            {
                var p = root;
                foreach (var c in words[i])
                {
                    if (!p.subNodes.TryGetValue(c, out TrieNode value))
                    {
                        value = new TrieNode(c);
                        p.subNodes.Add(c, value);
                    }

                    p = value;
                }

                p.indices.Add(i);
            }

            return root;
        }
    }
}
