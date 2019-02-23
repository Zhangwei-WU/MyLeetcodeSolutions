#pragma once

#include <vector>
#include <stack>

using namespace std;

namespace P150
{
	class Solution 
	{
	public:
		int evalRPN(vector<string>& tokens)
		{
			stack<int> values;

			for (size_t i = 0, len = tokens.size(); i < len; ++i)
			{
				string token = tokens[i];
				char c = *token.data();
				int value = 0;

				if (token.size != 1 
					|| (c != '+' && c != '-' && c != '*' && c != '/')) 
					value = atoi(token.data());
				else
				{
					int right = values.top(); values.pop();
					value = values.top(); values.pop();
					
					if (c == '+') value += right;
					else if (c == '-') value -= right;
					else if (c == '*') value *= right;
					else if (c == '/') value /= right;
				}

				values.push(value);
			}

			return values.top();
		}
	};
}