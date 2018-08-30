/* Problem 329. Longest Increasing Path in a Matrix
 * https://leetcode.com/problems/longest-increasing-path-in-a-matrix/description/
 * 
 * Given an integer matrix, find the length of the longest increasing path.
 * From each cell, you can either move to four directions: left, right, up or down. You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).
 * 
 * Example 1:
 * nums = [
 *   [9,9,4],
 *   [6,6,8],
 *   [2,1,1]]
 *   
 * Return 4 
 * The longest increasing path is [1, 2, 6, 9].
 * 
 * Example 2:
 * nums = [
 *   [3,4,5],
 *   [3,2,6],
 *   [2,2,1]]
 *  
 * Return 4
 * The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.
 * 
 * AC: 259ms
 */

namespace LeetCode.P329
{
    using System;
    
    public class Solution
    {
        int[,] matrix;
        int x;
        int y;
        int[,] cache;

        public int LongestIncreasingPath(int[,] matrix)
        {
            this.matrix = matrix;
            x = matrix.GetLength(0);
            y = matrix.GetLength(1);
            cache = new int[x, y];

            int max = 0;
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    max = Math.Max(max, Search(i, j));
                }
            }

            return max;
        }
        private int Search(int i, int j)
        {
            int max = cache[i, j];
            if (max != 0) return max;

            max = 1;
            var curr = matrix[i, j];
            if (j != 0 && matrix[i, j - 1] > curr) max = Math.Max(max, 1 + Search(i, j - 1));
            if (j != y - 1 && matrix[i, j + 1] > curr) max = Math.Max(max, 1 + Search(i, j + 1));
            if (i != 0 && matrix[i - 1, j] > curr) max = Math.Max(max, 1 + Search(i - 1, j));
            if (i != x - 1 && matrix[i + 1, j] > curr) max = Math.Max(max, 1 + Search(i + 1, j));

            return cache[i, j] = max;
        }
    }
}
