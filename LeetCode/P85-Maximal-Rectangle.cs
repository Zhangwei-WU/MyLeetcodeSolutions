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
