/* Problem 146. LRU Cache
 * https://leetcode.com/problems/lru-cache/description/
 * 
 * Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.
 * 
 * get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
 * put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.
 * 
 * Follow up:
 * Could you do both operations in O(1) time complexity?
 * 
 * Example:
 * 
 * LRUCache cache = new LRUCache( capacity: 2 ); 
 * 
 * cache.put(1, 1);
 * cache.put(2, 2);
 * cache.get(1);       // returns 1
 * cache.put(3, 3);    // evicts key 2
 * cache.get(2);       // returns -1 (not found)
 * cache.put(4, 4);    // evicts key 1
 * cache.get(1);       // returns -1 (not found)
 * cache.get(3);       // returns 3
 * cache.get(4);       // returns 4
 * 
 * AC: 422ms
 */

namespace LeetCode.P146
{
    public class LRUCache
    {
        private class CacheBlock
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public CacheBlock Prev { get; set; }
            public CacheBlock Next { get; set; }
        }

        private System.Collections.Generic.Dictionary<int, CacheBlock> lrucache;
        private CacheBlock latest;
        public int Capacity { get; private set; }
        public LRUCache(int capacity)
        {
            Capacity = capacity < 0 ? 0 : capacity;
            lrucache = new System.Collections.Generic.Dictionary<int, CacheBlock>(Capacity);
            latest = null;
        }

        public int Get(int key)
        {
            CacheBlock block;
            if (!lrucache.TryGetValue(key, out block)) return -1;

            Elevate(block);
            return block.Value;
        }

        public void Put(int key, int value)
        {
            CacheBlock block;
            // no such block, try add it
            if (!lrucache.TryGetValue(key, out block))
            {
                Evict();

                Add(block = new CacheBlock
                {
                    Key = key,
                    Value = value
                });
            }
            else
            {
                block.Value = value;
                Elevate(block);
            }
        }

        private void Elevate(CacheBlock block)
        {
            if (block == latest) return;

            block.Next.Prev = block.Prev;
            if (block.Prev != null) block.Prev.Next = block.Next;

            var oldest = latest.Next != block ? latest.Next : block.Next;
            oldest.Prev = null;

            block.Next = oldest;
            block.Prev = latest;
            latest.Next = block;
            latest = block;
        }
        private void Add(CacheBlock block)
        {
            lrucache.Add(block.Key, block);

            if (latest != null)
            {
                block.Prev = latest;
                block.Next = latest.Next;
                latest.Next = block;
                latest = block;
            }
            else
            {
                latest = block;
                latest.Next = latest;
            }
        }
        private void Evict()
        {
            if (lrucache.Count != Capacity) return;

            var oldest = latest.Next;
            lrucache.Remove(oldest.Key);

            latest.Next = oldest.Next;
            oldest.Next.Prev = null;
        }
    }
}
