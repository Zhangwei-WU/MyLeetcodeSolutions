
namespace LeetCode.P127
{
    using System.Collections.Generic;

    public class Solution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            graph.Add(beginWord, new List<string>());
            foreach (var word in wordList)
            {
                if (graph.ContainsKey(word)) continue;

                var list = new List<string>();
                graph.Add(word, list);
                foreach (var node in graph)
                {
                    var key = node.Key;
                    if (word == key) continue;

                    if (Edge(word, key))
                    {
                        list.Add(key);
                        node.Value.Add(word);
                    }
                }
            }

            if (!graph.ContainsKey(endWord)) return 0;
            // find from beginWord to endWord

            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            Dictionary<string, int> dist = new Dictionary<string, int>();

            visited.Add(beginWord);
            dist[beginWord] = 1;
            queue.Enqueue(beginWord);

            var found = false;
            while (queue.Count != 0 && !found)
            {
                var node = queue.Dequeue();
                var distance = dist[node];
                foreach (var neighber in graph[node])
                {
                    if (!visited.Add(neighber)) continue;
                    dist.Add(neighber, distance + 1);
                    if (neighber == endWord)
                    {
                        found = true;
                        break;
                    }
                    queue.Enqueue(neighber);
                }
            }

            if (!found) return 0;
            return dist[endWord];
        }

        private bool Edge(string word1, string word2)
        {
            bool found = false;
            for (int i = 0, len = word1.Length; i < len; i++)
            {
                if (word1[i] == word2[i]) continue;
                found = !found;
                if (!found) return false;
            }

            return found;
        }
    }
}
