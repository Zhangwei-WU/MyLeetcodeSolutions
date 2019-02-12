
namespace LeetCode.P39
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            return Dfs(candidates, 0, candidates.Length, target).ToArray();
        }

        private IEnumerable<IList<int>> Dfs(int[] candidates, int index, int length, int target)
        {
            if (target == 0)
            {
                yield return new List<int>();
                yield break;
            }

            for (var i = index; i < length; ++i)
            {
                var newtarget = target - candidates[i];

                if (newtarget < 0) yield break;
                else
                {
                    foreach (var solution in Dfs(candidates, i, length, newtarget))
                    {
                        solution.Add(candidates[i]);
                        yield return solution;
                    }
                }
            }
        }
    }
}
