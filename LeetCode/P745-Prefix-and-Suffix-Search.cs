/* Problem 745. Prefix and Suffix Search
 * https://leetcode.com/problems/prefix-and-suffix-search/description/
 * 
 * Given many words, words[i] has weight i.
 * Design a class WordFilter that supports one function, WordFilter.f(String prefix, String suffix). It will return the word with given prefix and suffix with maximum weight. If no word exists, return -1.
 * 
 * Examples:
 * Input:
 * WordFilter(["apple"])
 * WordFilter.f("a", "e") // returns 0
 * WordFilter.f("b", "") // returns -1
 * 
 * Note:
 *  - words has length in range [1, 15000].
 *  - For each test case, up to words.length queries WordFilter.f may be made.
 *  - words[i] has length in range [1, 10].
 *  - prefix, suffix have lengths in range [0, 10].
 *  - words[i] and prefix, suffix queries consist of lowercase letters only.
 *  
 */

namespace LeetCode.P745
{
    using System.Collections.Generic;
    using System.Linq;

    public class TrieNode
    {
        public TrieNode(int weight)
        {
            Next = new Dictionary<int, TrieNode>();
            Weight = weight;
        }

        public Dictionary<int, TrieNode> Next;
        public int Weight;
    }

    public class WordFilter
    {
        public WordFilter(string[] words)
        {
            BuildTrie(words);
        }

        public int F(string prefix, string suffix)
        {
            return GetMaxNode(trie, GetChars(prefix, suffix).ToArray(), 0);
        }

        private TrieNode trie = null;
        private IEnumerable<int> GetChars(string word)
        {
            var wordlen = word.Length;
            for (var j = 0; j < wordlen; j++)
            {
                yield return word[j] - 'a';
                yield return word[wordlen - j - 1] - 'a';
            }
        }

        private IEnumerable<int> GetChars(string prefix, string suffix)
        {
            suffix = new string(suffix.Reverse().ToArray());
            var len = System.Math.Max(prefix.Length, suffix.Length);
            for (var i = 0; i < len; i++)
            {
                yield return prefix.Length <= i ? -1 : prefix[i] - 'a';
                yield return suffix.Length <= i ? -1 : suffix[i] - 'a';
            }
        }

        private void BuildTrie(string[] words)
        {
            var len = words.Length - 1;
            trie = new TrieNode(len);

            for (var i = len; i >= 0; i--)
            {
                var ptr = trie;
                foreach (var c in GetChars(words[i]))
                {
                    TrieNode next;
                    if (!ptr.Next.TryGetValue(c, out next)) ptr.Next.Add(c, next = new TrieNode(i));
                    ptr = next;
                }
            }
        }

        private int GetMaxNode(TrieNode trie, int[] chars, int pos)
        {
            if (pos >= chars.Length) return trie.Weight;
            else if (chars[pos] == -1) return trie.Next.Count == 0 ? -1 : trie.Next.Max(p => GetMaxNode(p.Value, chars, pos + 1));
            else return !trie.Next.TryGetValue(chars[pos], out trie) ? -1 : GetMaxNode(trie, chars, pos + 1);
        }
    }
}