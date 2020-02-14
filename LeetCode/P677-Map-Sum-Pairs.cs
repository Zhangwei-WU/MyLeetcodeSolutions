
namespace LeetCode.P677
{
    using System.Collections.Generic;

    public class MapSum
    {
        private class Trie
        {
            public char c;
            public int v;
            public Dictionary<char, Trie> s;
            public Trie GetOrAdd(char c)
            {
                if (s == null) s = new Dictionary<char, Trie>();
                if (!s.TryGetValue(c, out Trie sub)) s.Add(c, sub = new Trie { c = c });
                return sub;
            }
            public Trie Get(char c)
            {
                if (s == null || !s.TryGetValue(c, out Trie sub)) return null;
                return sub;
            }
            public int Sum()
            {
                var sum = v;
                if (s != null) foreach (var sub in s.Values) sum += sub.Sum();
                return sum;
            }
        }

        private Trie trie;

        /** Initialize your data structure here. */
        public MapSum()
        {
            trie = new Trie { c = '\0' };
        }

        public void Insert(string key, int val)
        {
            var r = trie;
            foreach (var c in key)
            {
                r = r.GetOrAdd(c);
            }

            r.v = val;
        }

        public int Sum(string prefix)
        {
            var r = trie;
            foreach (var c in prefix)
            {
                if (r == null) break;
                r = r.Get(c);
            }

            if (r == null) return 0;
            return r.Sum();
        }
    }

    /**
     * Your MapSum object will be instantiated and called as such:
     * MapSum obj = new MapSum();
     * obj.Insert(key,val);
     * int param_2 = obj.Sum(prefix);
     */
}
