#pragma once

#include <vector>

namespace P632
{
	using namespace std;

	class MinHeap
	{
	public:
		struct KV { public: int Key; int Value; };

		MinHeap(size_t capacity)
		{
			this->capacity = capacity;
			arr = new KV[this->capacity + 1];
		}

		~MinHeap()
		{
			delete arr;
		}

		bool Add(int key, int val)
		{
			size_t p = ++n;
			if (p > capacity) return false;

			while (p > 1 && key < arr[p >> 1].Key)
			{
				arr[p] = arr[p >> 1];
				p >>= 1;
			}

			arr[p].Key = key;
			arr[p].Value = val;

			return true;
		}

		KV RemoveMin()
		{
			size_t p = 1, c = 2, x = n - 1;
			int val = arr[n].Key;
			KV e = arr[p];

			while (c <= x)
			{
				if (c < x && arr[c + 1].Key < arr[c].Key) c++;
				if (arr[c].Key >= val) break;

				arr[p] = arr[c];
				p = c;
				c <<= 1;
			}

			arr[p] = arr[x + 1];
			n--;

			return e;
		}

		void ReplaceMin(int key, int val)
		{
			size_t p = 1, c = 2, x = n;

			while (c <= x)
			{
				if (c < x && arr[c + 1].Key < arr[c].Key) c++;
				if (arr[c].Key >= key) break;

				arr[p] = arr[c];
				p = c;
				c <<= 1;
			}

			arr[p].Key = key;
			arr[p].Value = val;
		}

		KV Peek() { return n == 0 ? KV() : arr[1]; }
		void Clear() { n = 0; }
		size_t Count() { return n; }

	private:
		KV* arr;
		size_t n = 0;
		size_t capacity = 0;
	};

	class Solution 
	{
	public:
		vector<int> smallestRange(vector<vector<int>>& nums)
		{
			size_t len = nums.size();
			int* lens = new int[len] {0};
			int* poss = new int[len] {0};
			MinHeap head(len);

			int min = -100001, max = 100001, tempmax = min;
			for (size_t i = 0; i < len; i++)
			{
				lens[i] = nums[i].size();
				int val = nums[i][poss[i]++];
				head.Add(val, i);
				if (val > tempmax) tempmax = val;
			}

			while (true)
			{
				MinHeap::KV peek = head.Peek();
				int gap = tempmax - peek.Key;
				if (gap < max - min) min = peek.Key, max = tempmax;

				int i = peek.Value;
				int pos = poss[i];

				if (gap == 0 || pos == lens[i])
				{
					delete lens;
					delete poss;
					vector<int> result;
					result.push_back(min);
					result.push_back(max);
					return result;
				}

				vector<int> num = nums[i];
				while (pos != lens[i] - 1 && num[pos] == num[pos + 1]) pos++;
				int val = num[pos];
				poss[i] = pos + 1;
				head.ReplaceMin(val, i);
				if (val > tempmax) tempmax = val;
			}

		}
	};

}