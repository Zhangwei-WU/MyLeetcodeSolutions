namespace LeetCode.P380
{
    using System;
    using System.Collections.Generic;

    public class RandomizedSet
    {
        private HashSet<int> hashset;
        private Random rnd;
        private bool needRefresh = false;
        private int[] resultCopy;
        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            hashset = new HashSet<int>();
            rnd = new Random();
            resultCopy = new int[0];
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            var result = hashset.Add(val);
            needRefresh |= result;
            return result;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            var result = hashset.Remove(val);
            needRefresh |= result;
            return result;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            if (needRefresh)
            {
                needRefresh = false;
                if (hashset.Count > resultCopy.Length) resultCopy = new int[hashset.Count];
                hashset.CopyTo(resultCopy);
            }

            return resultCopy[rnd.Next(hashset.Count)];
        }
    }
}
