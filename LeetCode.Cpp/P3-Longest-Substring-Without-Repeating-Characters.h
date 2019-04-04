#pragma once

#include <string>

using namespace std;

namespace P3
{
	class Solution 
	{
	public:
		int lengthOfLongestSubstring(string s) 
		{
			int pos[128];
			for (int i = 0; i < 128; ++i) pos[i] = -1;

			int maxLen = 0, maxPos = -1;
			for (size_t i = 0, len = s.length(); i < len; ++i)
			{
				int c = s[i];
				maxLen = max(i - (maxPos = max(pos[c], maxPos)), maxLen);
				pos[c] = i;
			}

			return maxLen;
		}

		inline int max(int a, int b) { return a > b ? a : b; }
	};

}