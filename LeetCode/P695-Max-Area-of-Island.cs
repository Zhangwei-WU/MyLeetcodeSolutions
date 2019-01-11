namespace LeetCode.P695
{

    public class Solution
    {
        public int MaxAreaOfIsland(int[,] grid)
        {
            var max = 0;

            var x = grid.GetLength(0);
            var y = grid.GetLength(1);

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    var area = Dfs(grid, i, j, x, y);
                    if (area > max) max = area;
                }
            }

            return max;
        }

        public int Dfs(int[,] grid, int i, int j, int x, int y)
        {
            if (i < 0 || i >= x || j < 0 || j >= y) return 0;
            if (grid[i, j] == 0) return 0;

            var cnt = 1;
            grid[i, j] = 0;
            cnt += Dfs(grid, i - 1, j, x, y);
            cnt += Dfs(grid, i + 1, j, x, y);
            cnt += Dfs(grid, i, j - 1, x, y);
            cnt += Dfs(grid, i, j + 1, x, y);

            return cnt;
        }

    }
}
