#pragma once

#include <vector>

namespace P33
{
	using namespace std;

	class Solution
	{
	public:
		int search(vector<int>& nums, int target)
		{
			if (nums.empty()) return -1;
			size_t len = nums.size();
			for (int start = 0, end = len - 1; start <= end;)
			{
				int nstart = nums[start];
				if (target == nstart) return start;

				int nend = nums[end];
				if (target == nend) return end;
				if (nstart <= nend) return BinarySearch(nums, start + 1, end - start - 1, target);

				int mid = (start + end) / 2;
				int nmid = nums[mid];
				if (target == nmid) return mid;

				if (nstart < nmid)
				{
					if (target > nstart && target < nmid) return BinarySearch(nums, start + 1, mid - start - 1, target);
					start = mid + 1;
				}
				else
				{
					if (target > nmid && target < nend) return BinarySearch(nums, mid + 1, end - mid - 1, target);
					end = mid - 1;
				}
			}

			return -1;
		}

	private:
		int BinarySearch(vector<int>& arr, int index, int length, int value)
		{
			int lo = index, hi = index + length - 1;
			while (lo <= hi)
			{
				int i = lo + ((hi - lo) >> 1);
				int order = arr[i] - value;

				if (order == 0) return i;

				if (order < 0) lo = i + 1;
				else hi = i - 1;
			}

			return -1;
		}
	};
}