namespace LeetCode.P208
{
    using System.Collections.Generic;

    public class Trie
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

        private TrieNode root;
        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode('\0');
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var p = root;
            foreach(var c in word)
            {
                TrieNode subNode;
                if(!p.SubNodes.TryGetValue(c, out subNode))
                {
                    subNode = new TrieNode(c);
                    p.SubNodes.Add(c, subNode);
                }

                p = subNode;
            }

            p.B = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var p = root;
            foreach(var c in word)
            {
                if(!p.SubNodes.TryGetValue(c, out p)) return false;
            }

            return p.B;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var p = root;
            foreach(var c in prefix)
            {
                if (!p.SubNodes.TryGetValue(c, out p)) return false;
            }

            return true;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
