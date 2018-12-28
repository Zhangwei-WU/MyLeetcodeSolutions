using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.P200
{
    public class Solution
    {
        public int NumIslands(char[,] grid)
        {
            var cnt = 0;

            var x = grid.GetLength(0);
            var y = grid.GetLength(1);

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (Dfs(grid, i, j, x, y)) cnt++;
                }
            }

            return cnt;
        }
        
        public bool Dfs(char[,] grid, int i, int j, int x, int y)
        {
            if (i < 0 || i >= x || j < 0 || j >= y) return false;
            if (grid[i, j] == '0') return false;

            grid[i, j] = '0';
            Dfs(grid, i - 1, j, x, y);
            Dfs(grid, i + 1, j, x, y);
            Dfs(grid, i, j - 1, x, y);
            Dfs(grid, i, j + 1, x, y);

            return true;
        }
    }
}
