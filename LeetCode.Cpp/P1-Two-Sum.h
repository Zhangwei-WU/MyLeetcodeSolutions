#pragma once

#include <vector>
#include <algorithm>
#include <unordered_map>

using namespace std;

namespace P1
{
	class Solution
	{
	public:
		vector<int> twoSum(vector<int>& nums, int target) 
		{
			unordered_map<int, size_t> map;

			for (size_t i = 0, len = nums.size(); i < len; ++i)
			{
				int m = nums[i];
				auto find = map.find(target - m);
				if (find != map.end())
				{
					vector<int> result;
					result.push_back(i);
					result.push_back(find->second);
					if (result[0] > result[1]) iter_swap(result.begin(), result.begin() + 1);
					return result;
				}
				
				map[m] = i;
			}

			throw 1;
		}
	};
}
