/* Problem 460. LFU Cache
 * https://leetcode.com/problems/lfu-cache/description/
 * 
 * Design and implement a data structure for Least Frequently Used (LFU) cache. It should support the following operations: get and put.
 * get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
 * put(key, value) - Set or insert the value if the key is not already present. 
 *     When the cache reaches its capacity, it should invalidate the least frequently used item before inserting a new item. 
 *     For the purpose of this problem, when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted.
 * 
 * Follow up:
 * Could you do both operations in O(1) time complexity?
 * 
 * Example:
 * LFUCache cache = new LFUCache( capacity: 2 );
 * cache.put(1, 1);
 * cache.put(2, 2);
 * cache.get(1);       // returns 1
 * cache.put(3, 3);    // evicts key 2
 * cache.get(2);       // returns -1 (not found)
 * cache.get(3);       // returns 3.
 * cache.put(4, 4);    // evicts key 1.
 * cache.get(1);       // returns -1 (not found)
 * cache.get(3);       // returns 3
 * cache.get(4);       // returns 4
 * 
 */

namespace LeetCode.P460
{
    public class LFUCache
    {
        private class CacheBlock
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public CacheBlock Prev { get; set; }
            public CacheBlock Next { get; set; }
            public int Frequency { get; set; }
        }
        
        private System.Collections.Generic.Dictionary<int, CacheBlock> lfucache;
        private CacheBlock least;
        public int Capacity { get; private set; }
        public LFUCache(int capacity)
        {
            Capacity = capacity < 0 ? 0 : capacity;
            lfucache = new System.Collections.Generic.Dictionary<int, CacheBlock>(Capacity);
            least = null;
        }

        public int Get(int key)
        {
            CacheBlock block;
            if (!lfucache.TryGetValue(key, out block)) return -1;

            block.Frequency++;
            Elevate(block);

            return block.Value;
        }

        public void Put(int key, int value)
        {
            if (Capacity == 0) return;
            CacheBlock block;
            if(!lfucache.TryGetValue(key, out block))
            {
                // add block
                Evict();
                Add(new CacheBlock
                {
                    Key = key,
                    Value = value
                });
            }
            else
            {
                block.Value = value;
                block.Frequency++;
                Elevate(block);
            }
        }

        private void Elevate(CacheBlock block)
        {
            CacheBlock target = block;

            // can we do better? faster find the position to insert
            while (target.Next != null && target.Next.Frequency <= block.Frequency) target = target.Next;
            if (target == block) return;

            if (block == least)
            {
                least = block.Next;
                least.Prev = null;
            }
            else
            {
                block.Prev.Next = block.Next;
                block.Next.Prev = block.Prev;
            }

            // insert block after target
            if (target.Next != null) target.Next.Prev = block;
            block.Next = target.Next;
            block.Prev = target;
            target.Next = block;
        }
        private void Add(CacheBlock block)
        {
            lfucache.Add(block.Key, block);

            block.Frequency = 1;
            block.Next = least;
            if (least != null) least.Prev = block;
            least = block;

            Elevate(least);
        }
        private void Evict()
        {
            if (lfucache.Count != Capacity) return;
            lfucache.Remove(least.Key);
            if (least.Next != null) least.Next.Prev = null;
            least = least.Next;
        }
    }

}

namespace LeetCode.P460.S2
{
    using System.Collections.Generic;

    public class LFUCache
    {
        private class CacheBlock
        {
            public CacheBlock(int key, int value, int frequency)
            {
                Key = key;
                Value = value;
                Frequency = frequency;
            }
            public int Key { get; set; }
            public int Value { get; set; }
            public int Frequency { get; set; }
        }

        private Dictionary<int, LinkedListNode<CacheBlock>> lfucache;
        private Dictionary<int, LinkedList<CacheBlock>> distrib;
        private int leastfreq;

        public int Capacity { get; private set; }
        public LFUCache(int capacity)
        {
            Capacity = capacity < 0 ? 0 : capacity;
            lfucache = new Dictionary<int, LinkedListNode<CacheBlock>>(Capacity);
            distrib = new Dictionary<int, LinkedList<CacheBlock>>();
            distrib.Add(1, new LinkedList<CacheBlock>());
            leastfreq = 0;
        }

        public int Get(int key)
        {
            LinkedListNode<CacheBlock> block;
            if (!lfucache.TryGetValue(key, out block)) return -1;
            
            Elevate(block);

            return block.Value.Value;
        }

        public void Put(int key, int value)
        {
            if (Capacity == 0) return;
            LinkedListNode<CacheBlock> block;
            if (!lfucache.TryGetValue(key, out block))
            {
                if (lfucache.Count == Capacity)
                {
                    var needRemove = distrib[leastfreq].First;
                    lfucache.Remove(needRemove.Value.Key);
                    needRemove.List.RemoveFirst();
                }

                block = new LinkedListNode<CacheBlock>(new CacheBlock(key, value, 1));

                lfucache.Add(key, block);
                distrib[leastfreq = 1].AddLast(block);
            }
            else
            {
                block.Value.Value = value;
                Elevate(block);
            }
        }

        private void Elevate(LinkedListNode<CacheBlock> block)
        {
            var newfreq = ++block.Value.Frequency;
            var originalList = block.List;
            originalList.Remove(block);

            if (originalList.Count == 0 && newfreq - 1 == leastfreq) leastfreq = newfreq;

            LinkedList<CacheBlock> newFreqList;
            if (!distrib.TryGetValue(newfreq, out newFreqList))
            {
                newFreqList = new LinkedList<CacheBlock>();
                distrib.Add(newfreq, newFreqList);
            }

            newFreqList.AddLast(block);
        }
    }
}