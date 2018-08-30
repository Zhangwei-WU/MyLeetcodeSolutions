#pragma once
#include <vector>

namespace P33
{
	using namespace std;

	class Solution 
	{
	public:
		void solveSudoku(vector<vector<char>>& board) 
		{
			uint8_t data[81];
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					data[i * 9 + j] = GetNumber(board[i][j]);
				}
			}

			TryFillCell(data, 0);

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					board[i][j] = GetChar(data[i * 9 + j]);
				}
			}

		}

	private:
		uint8_t GetNumber(char c)
		{
			if (c == '.') return 0;
			return (uint8_t)(c - '0');
		}

		char GetChar(uint8_t c)
		{
			return (char)('0' + c);
		}

		static bool TryFillCell(uint8_t* data, int index)
		{
			if (index == 81) return true;
			if (data[index] != 0) return TryFillCell(data, index + 1);

			int rowptr = index / 9 * 9, colptr = index - rowptr, bktptr = rowptr / 27 * 27 + colptr / 3 * 3, p = 0;

			p = (shiftval[data[rowptr]] | shiftval[data[rowptr + 1]] | shiftval[data[rowptr + 2]]
				| shiftval[data[rowptr + 3]] | shiftval[data[rowptr + 4]] | shiftval[data[rowptr + 5]]
				| shiftval[data[rowptr + 6]] | shiftval[data[rowptr + 7]] | shiftval[data[rowptr + 8]]);
			if (p == 0x1FF) return false;
			p |= (shiftval[data[colptr]] | shiftval[data[colptr + 9]] | shiftval[data[colptr + 18]]
				| shiftval[data[colptr + 27]] | shiftval[data[colptr + 36]] | shiftval[data[colptr + 45]]
				| shiftval[data[colptr + 54]] | shiftval[data[colptr + 63]] | shiftval[data[colptr + 72]]);
			if (p == 0x1FF) return false;
			p |= (shiftval[data[bktptr]] | shiftval[data[bktptr + 1]] | shiftval[data[bktptr + 2]]
				| shiftval[data[bktptr + 9]] | shiftval[data[bktptr + 10]] | shiftval[data[bktptr + 11]]
				| shiftval[data[bktptr + 18]] | shiftval[data[bktptr + 19]] | shiftval[data[bktptr + 20]]);
			if (p == 0x1FF) return false;

			for (int i = 1; i < 10; i++)
			{
				if ((p & shiftval[i]) != 0) continue;
				data[index] = i;
				if (TryFillCell(data, index + 1)) return true;
			}

			data[index] = 0;
			return false;
		}

		static const int shiftval[];
	};

	const int Solution::shiftval[] = { 0x0000, 0x0001, 0x0002, 0x0004, 0x0008, 0x0010, 0x0020, 0x0040, 0x0080, 0x0100 };
}