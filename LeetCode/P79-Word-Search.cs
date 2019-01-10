
namespace LeetCode.P79
{
    public class Solution
    {
        public bool Exist(char[,] board, string word)
        {
            var chars = word.ToCharArray();
            var len = chars.Length;

            var li = board.GetLength(0);
            var lj = board.GetLength(1);

            for (var i = 0; i < li; i++)
            {
                for (var j = 0; j < lj; j++)
                {
                    if (Search(board, i, j, li, lj, chars, 0, len)) return true;
                }
            }

            return false;
        }

        private bool Search(char[,] board, int i, int j, int li, int lj, char[] chars, int index, int length)
        {
            if (index == length) return true;
            if (i < 0 || j < 0 || i == li || j == lj) return false;
            var c = board[i, j];
            if (c != chars[index]) return false;
            board[i, j] = '\0';
            if (Search(board, i - 1, j, li, lj, chars, index + 1, length)
                || Search(board, i, j - 1, li, lj, chars, index + 1, length)
                || Search(board, i + 1, j, li, lj, chars, index + 1, length)
                || Search(board, i, j + 1, li, lj, chars, index + 1, length))
                return true;

            board[i, j] = c;
            return false;
        }
    }
}
