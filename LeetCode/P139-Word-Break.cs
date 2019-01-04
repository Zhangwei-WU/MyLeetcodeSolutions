namespace LeetCode.P139
{
    using System.Collections.Generic;

    public class Solution
    {
        private class TrieNode
        {
            public char C { get; private set; }
            public Dictionary<char, TrieNode> SubNodes { get; private set; }
            public bool B { get; set; }
            public TrieNode(char c)
            {
                C = c;
                SubNodes = new Dictionary<char, TrieNode>();
            }
        }

        /** Inserts a word into the trie. */
        private void Insert(string word, TrieNode root, HashSet<char> filters)
        {
            var p = root;
            foreach (var c in word)
            {
                filters.Add(c);
                if (!p.SubNodes.TryGetValue(c, out TrieNode subNode))
                {
                    subNode = new TrieNode(c);
                    p.SubNodes.Add(c, subNode);
                }

                p = subNode;
            }

            p.B = true;
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            var trie = new TrieNode('\0');
            var filters = new HashSet<char>();
            foreach (var word in wordDict) Insert(word, trie, filters);

            var chars = s.ToCharArray();
            foreach (var c in chars) if (!filters.Contains(c)) return false;
            var records = new bool[chars.Length];
            return Search(chars, 0, chars.Length, trie, records);
        }

        private bool Search(char[] chars, int index, int length, TrieNode trie, bool[] records)
        {
            if (index == length) return true;
            if (records[index]) return false;

            var p = trie;
            for (var i = index; i < length; i++)
            {
                var c = chars[i];
                if (!p.SubNodes.TryGetValue(c, out TrieNode sub)) break;
                if (sub.B && Search(chars, i + 1, length, trie, records)) return true;
                p = sub;
            }

            records[index] = true;
            return false;
        }
    }
}
