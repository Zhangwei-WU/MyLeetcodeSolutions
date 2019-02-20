#pragma once

#include <vector>
using namespace std;

namespace P33
{

	class Solution
	{
	public:
		int search(vector<int>& nums, int target)
		{
			if (nums.empty()) return -1;

			for (size_t len = nums.size(), l = 0, h = len - 1; l <= h;)
			{
				size_t m = l + (h - l) / 2;
				int cp = nums[m] - target;
				if (cp == 0) return m;

				if (nums[l] <= nums[m])
				{
					if (target >= nums[l] && cp > 0) h = m - 1;
					else l = m + 1;
				}
				else
				{
					if (target <= nums[h] && cp < 0) l = m + 1;
					else h = m - 1;
				}
			}

			return -1;
		}
	};
}