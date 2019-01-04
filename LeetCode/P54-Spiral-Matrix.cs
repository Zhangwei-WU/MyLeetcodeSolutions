namespace LeetCode.P54
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<int> SpiralOrder(int[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            var result = new int[m * n];

            for (int i = 0, x = 0, k = ((m > n ? n : m) + 1) / 2; i < k; i++, m--, n--)
            {
                int m1 = m - 1, n1 = n - 1;
                for (var j = i; j < n; j++) result[x++] = matrix[i, j];
                for (var j = i + 1; j < m; j++) result[x++] = matrix[j, n1];
                if (m1 > i) for (var j = n1 - 1; j >= i; j--) result[x++] = matrix[m1, j];
                if (n1 > i) for (var j = m1 - 1; j > i; j--) result[x++] = matrix[j, i];
            }

            return result;
        }
    }
}
