
namespace LeetCode.P1282
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            var ids = new KeyValuePair<int, int>[groupSizes.Length];
            for(var i=0;i<groupSizes.Length;++i)
            {
                ids[i] = new KeyValuePair<int, int>(i, groupSizes[i]);
            }

            Array.Sort(ids, (a, b) => a.Value - b.Value);

            var result = new List<IList<int>>();

            for(int i = 0, size = 0; i < groupSizes.Length && (size = ids[i].Value) != -1; i += size)
            {
                var group = new List<int>(size);
                for (var j = 0; j < size; ++j) group.Add(ids[i + j].Key);
                result.Add(group);
            }

            return result;
        }
    }
}
