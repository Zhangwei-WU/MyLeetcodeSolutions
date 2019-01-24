namespace LeetCode.P85
{
    public class Solution
    {
        public int MaximalRectangle(char[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            var maxsize = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (matrix[i, j] == '0') continue;

                    var maxj = n;
                    for (var ii = i; ii < m; ii++)
                    {
                        if (matrix[ii, j] == '0') break;
                        for (var jj = j + 1; jj < maxj; jj++)
                        {
                            if (matrix[ii, jj] == '0')
                            {
                                maxj = jj;
                                break;
                            }
                        }

                        maxsize = System.Math.Max(maxsize, (ii - i + 1) * (maxj - j));
                    }
                }
            }

            return maxsize;
        }
    }

}

namespace LeetCode.P85.S2
{
    public class Solution
    {
        public int MaximalRectangle(char[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            for (var i = 0; i < m; i++)
            {
                var t = n;
                for (var j = n - 1; j >= 0; j--)
                {
                    if (matrix[i, j] == '0') t = j;
                    else matrix[i, j] = (char)(t + '0');
                }
            }

            var maxsize = 0;
            for (var i = 0; i < m; i++)
            {
                for (int j = 0, maxj; j < n; j++)
                {
                    if ((maxj = matrix[i, j] - '0') == 0) continue;
                    if ((maxj -= j) > maxsize) maxsize = maxj;
                    if ((m - i) * maxj < maxsize) continue;

                    for (int ii = i + 1, t; ii < m; ii++)
                    {
                        if ((t = matrix[ii, j] - '0') == 0) break;
                        if ((t -= j) < maxj) maxj = t;
                        if ((t = (ii - i + 1) * maxj) > maxsize) maxsize = t;
                    }
                }
            }

            return maxsize;
        }
    }
}
