namespace LeetCode.P289
{
    public class Solution
    {
        public void GameOfLife(int[][] board)
        {
            var m = board.Length;
            if (m == 0) return;
            var n = board[0].Length;

            int[] prevline = null, currline = board[0], nextline = null;
            for (var i = 0; i < m; i++)
            {
                nextline = i != m - 1 ? board[i + 1] : null;
                for (var j = 0; j < n; j++)
                {
                    var neighbors = 0;

                    if (prevline != null)
                    {
                        if (j != 0 && (prevline[j - 1] & 0x1) == 1) neighbors++;
                        if ((prevline[j] & 0x1) == 1) neighbors++;
                        if (j != n - 1 && (prevline[j + 1] & 0x1) == 1) neighbors++;
                    }

                    if (j != 0 && (currline[j - 1] & 0x1) == 1) neighbors++;
                    if (j != n - 1 && currline[j + 1] == 1) neighbors++;

                    if (nextline != null)
                    {
                        if (j != 0 && nextline[j - 1] == 1) neighbors++;
                        if (nextline[j] == 1) neighbors++;
                        if (j != n - 1 && nextline[j + 1] == 1) neighbors++;
                    }

                    if (currline[j] == 1)
                    {
                        if (neighbors == 2 || neighbors == 3) currline[j] = 3;
                    }
                    else
                    {
                        if (neighbors == 3) currline[j] = 2;
                    }
                }

                prevline = currline;
                currline = nextline;
            }

            for (var i = 0; i < m; i++)
            {
                var curr = board[i];
                for (var j = 0; j < n; j++)
                {
                    curr[j] = curr[j] >> 1;
                }
            }
        }
    }
}
