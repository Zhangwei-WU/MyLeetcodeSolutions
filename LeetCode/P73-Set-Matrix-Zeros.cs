
namespace LeetCode.P73
{
    public class Solution
    {
        public void SetZeroes(int[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            var dummy = -23945858;
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (matrix[i, j] == 0)
                    {
                        for (var k = 0; k < m; ++k)
                        {
                            if (matrix[k, j] != 0) matrix[k, j] = dummy;
                        }

                        for (var k = 0; k < n; ++k)
                        {
                            if (matrix[i, k] != 0) matrix[i, k] = dummy;
                        }
                    }
                }
            }

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (matrix[i, j] == dummy) matrix[i, j] = 0;
                }
            }
        }
    }
}
