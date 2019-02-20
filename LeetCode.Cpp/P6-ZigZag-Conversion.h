#pragma once

#include <string>

using namespace std;

namespace P6
{

	class Solution 
	{
	public:
		string convert(string s, int numRows) 
		{
			if (numRows == 1 || s.length() <= 1) return s;

			size_t len = s.length(), step = 2 * numRows - 2;

			auto ptr = s.data();

			string result(len, 0);
			size_t iter = 0;

			for (size_t i = 0; i < len; i += step) result[iter++] = ptr[i];
			for (size_t i = 1; i < numRows - 1; ++i)
			{
				for (size_t j = i; j < len; j += step)
				{
					result[iter++] = ptr[j];
					size_t other = j + step - 2 * i;
					if (other >= len) break;
					result[iter++] = ptr[other];
				}
			}
			for (size_t i = numRows - 1; i < len; i += step) result[iter++] = ptr[i];
			
			return result;
		}
	};
}