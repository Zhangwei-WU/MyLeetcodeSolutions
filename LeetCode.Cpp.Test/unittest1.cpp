#include "stdafx.h"
#include "CppUnitTest.h"
#include "../LeetCode.Cpp/P231-Power-of-Two.h"
#include "../LeetCode.Cpp/P632-Smallest-Range.h"
#include "../LeetCode.Cpp/P33-Search-in-Rotated-Sorted-Array.h"
#include "../LeetCode.Cpp/P745-Prefix-and-Suffix-Search.h"
#include "../LeetCode.Cpp/P1-Two-Sum.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace LeetCodeCppTest
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(CppTestPowerOfTwo)
		{
			P231::Solution solution;
			Assert::IsTrue(solution.isPowerOfTwo(2));
		}

		TEST_METHOD(CppTestSmallestRange)
		{
			P632::Solution solution;
			int e1[] = { 4,10,15,24,26 };
			int e2[] = { 0, 9, 12,20 };
			int e3[] = { 5, 18, 22, 30 };

			std::vector<std::vector<int>> list;
			list.push_back(std::vector<int>(e1, e1 + sizeof(e1) / sizeof(int)));
			list.push_back(std::vector<int>(e2, e2 + sizeof(e2) / sizeof(int)));
			list.push_back(std::vector<int>(e3, e3 + sizeof(e3) / sizeof(int)));

			std::vector<int> result = solution.smallestRange(list);
			Assert::AreEqual(20, result[0]);
			Assert::AreEqual(24, result[1]);
		}

		TEST_METHOD(CppTestSearchinRotatedSortedArray)
		{
			P33::Solution solution;
			int data1[] = { 4, 5, 6, 7, 8, 0, 1, 2, 3 };

			Assert::AreEqual(5, solution.search(std::vector<int>(data1, data1 + sizeof(data1) / sizeof(int)), 0));

			int data2[] = { 1 };
			Assert::AreEqual(-1, solution.search(std::vector<int>(data2, data2 + sizeof(data2) / sizeof(int)), 0));
		}

		TEST_METHOD(CppTestPrefixandSuffixSearch)
		{
			// "apple", "apple", "appae"
			std::vector<std::string> data;
			data.push_back("apple");
			data.push_back("apple");
			data.push_back("appae");

			P745::WordFilter filter(data);
			Assert::AreEqual(2, filter.f("a", "e"));
			Assert::AreEqual(-1, filter.f("a", "b"));
			Assert::AreEqual(1, filter.f("a", "le"));
		}

		TEST_METHOD(CppTestP1)
		{
			std::vector<int> data;
			data.push_back(2);
			data.push_back(7);
			data.push_back(15);
			data.push_back(11);

			P1::Solution solution;
			auto result = solution.twoSum(data, 9);
			Assert::AreEqual(0, result[0]);
			Assert::AreEqual(1, result[1]);
		}


	};
}