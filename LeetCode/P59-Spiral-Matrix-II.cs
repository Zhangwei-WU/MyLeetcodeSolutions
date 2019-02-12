
namespace LeetCode.P59
{
    public class Solution
    {
        public int[,] GenerateMatrix(int n)
        {
            var result = new int[n, n];

            for (int i = 0, m = n, x = 0, k = (n + 1) / 2; i < k; i++, m--, n--)
            {
                int m1 = m - 1, n1 = n - 1;
                for (var j = i; j < n; j++) result[i, j] = ++x;
                for (var j = i + 1; j < m; j++) result[j, n1] = ++x;
                if (m1 > i) for (var j = n1 - 1; j >= i; j--) result[m1, j] = ++x;
                if (n1 > i) for (var j = m1 - 1; j > i; j--) result[j, i] = ++x;
            }

            return result;
        }
    }
}
