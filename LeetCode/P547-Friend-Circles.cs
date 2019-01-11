
namespace LeetCode.P547
{
    using System.Collections.Generic;

    public class Solution
    {
        public int FindCircleNum(int[,] M)
        {
            var cnt = 0;
            Queue<int> queue = new Queue<int>();
            for (int i = 0, len = M.GetLength(0); i < len; i++)
            {
                if (M[i, i] == 0) continue;
                cnt++;

                queue.Enqueue(i);
                while (queue.Count != 0)
                {
                    var k = queue.Dequeue();
                    if (M[k, k] == 0) continue;
                    M[k, k] = 0;
                    for (var j = 0; j < len; j++) if (M[k, j] == 1) queue.Enqueue(j);
                }
            }

            return cnt;
        }
    }
}
