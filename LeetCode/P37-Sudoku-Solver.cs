/* Problem 37: Sudoku Solver
 * https://leetcode.com/problems/sudoku-solver/description/ 
 * 
 * Write a program to solve a Sudoku puzzle by filling the empty cells.
 * Empty cells are indicated by the character '.'.
 * You may assume that there will be only one unique solution.
 * 
 * AC: 198ms
 */

namespace LeetCode.P37
{
    public class Solution
    {
        public void SolveSudoku(char[,] board)
        {
            byte[] data = new byte[81];
            for (var i = 0; i < 9; i++) for (var j = 0; j < 9; j++) data[i * 9 + j] = GetNumber(board[i, j]);
            TryFillCell(data, 0);
            for (var i = 0; i < 9; i++) for (var j = 0; j < 9; j++) board[i, j] = GetChar(data[i * 9 + j]);
        }

        private byte GetNumber(char c) { return c == '.' ? (byte)0 : (byte)(c - '0'); }
        private char GetChar(byte c) { return (char)('0' + c); }

        static readonly int[] MASK = { 0x0000, 0x0001, 0x0002, 0x0004, 0x0008, 0x0010, 0x0020, 0x0040, 0x0080, 0x0100 };

        private static bool TryFillCell(byte[] data, int index)
        {
            if (index == 81) return true;
            if (data[index] != 0) return TryFillCell(data, index + 1);

            int rowptr = index / 9 * 9, colptr = index - rowptr, bktptr = rowptr / 27 * 27 + colptr / 3 * 3, p = 0;

            p = (MASK[data[rowptr]] | MASK[data[rowptr + 1]] | MASK[data[rowptr + 2]]
                | MASK[data[rowptr + 3]] | MASK[data[rowptr + 4]] | MASK[data[rowptr + 5]]
                | MASK[data[rowptr + 6]] | MASK[data[rowptr + 7]] | MASK[data[rowptr + 8]]);
            if (p == 0x1FF) return false;
            p |= (MASK[data[colptr]] | MASK[data[colptr + 9]] | MASK[data[colptr + 18]]
                | MASK[data[colptr + 27]] | MASK[data[colptr + 36]] | MASK[data[colptr + 45]]
                | MASK[data[colptr + 54]] | MASK[data[colptr + 63]] | MASK[data[colptr + 72]]);
            if (p == 0x1FF) return false;
            p |= (MASK[data[bktptr]] | MASK[data[bktptr + 1]] | MASK[data[bktptr + 2]]
                | MASK[data[bktptr + 9]] | MASK[data[bktptr + 10]] | MASK[data[bktptr + 11]]
                | MASK[data[bktptr + 18]] | MASK[data[bktptr + 19]] | MASK[data[bktptr + 20]]);
            if (p == 0x1FF) return false;

            for (int i = 1; i < 10; i++)
            {
                if ((p & MASK[i]) != 0) continue;
                data[index] = (byte)i;
                if (TryFillCell(data, index + 1)) return true;
            }

            data[index] = 0;
            return false;
        }
    }

}
