
namespace LeetCode.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using LeetCode.Generics;

    [TestClass]
    public partial class Tests
    {
        [TestMethod]
        public void TestP1()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 18;

            P1.Solution solution = new P1.Solution();
            var result = solution.TwoSum(nums, target);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
        }

        [TestMethod]
        public void TestP112()
        {
            var tree = new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    },
                    right = null
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        right = new TreeNode(1)
                    }
                }
            };

            var solution = new P112.Solution();
            Assert.IsTrue(solution.HasPathSum(tree, 22));
        }

        [TestMethod]
        public void TestP633()
        {
            var p633 = new P633.Solution();
            Assert.IsTrue(p633.JudgeSquareSum(32));
            Assert.IsFalse(p633.JudgeSquareSum(33));
        }

        [TestMethod]
        public void TestP179()
        {
            var p179 = new P179.Solution();
            Assert.AreEqual("12121", p179.LargestNumber(new int[] { 12, 121 }));
            Assert.AreEqual("0", p179.LargestNumber(new int[] { 0, 0}));
            Assert.AreEqual(string.Empty, p179.LargestNumber(new int[] { }));

        }

        [TestMethod]
        public void TestP755()
        {
            var p755 = new P755.Solution();

            Assert.AreEqual(1, p755.ReachNumber(1));
            Assert.AreEqual(2, p755.ReachNumber(3));
            Assert.AreEqual(3, p755.ReachNumber(6));
            Assert.AreEqual(3, p755.ReachNumber(2));
            Assert.AreEqual(5, p755.ReachNumber(5));
        }

        [TestMethod]
        public void TestP50()
        {
            var p50 = new P50.Solution();

            Assert.AreEqual(1.0d, p50.MyPow(1.0d, 2));
            Assert.AreEqual(4.0d, p50.MyPow(2.0d, 2));
            Assert.AreEqual(0.25d, p50.MyPow(2.0d, -2));
            Assert.AreEqual(27.0d, p50.MyPow(3.0d, 3));
        }

        [TestMethod]
        public void TestP66()
        {
            var p66 = new P66.Solution();

            CollectionAssert.AreEqual(new int[] { 1 }, p66.PlusOne(new int[] { 0 }));
            CollectionAssert.AreEqual(new int[] { 1, 0 }, p66.PlusOne(new int[] { 9 }));
            CollectionAssert.AreEqual(new int[] { 1, 0, 0 }, p66.PlusOne(new int[] { 9, 9 }));
            CollectionAssert.AreEqual(new int[] { 9, 9 }, p66.PlusOne(new int[] { 9, 8 }));
            CollectionAssert.AreEqual(new int[] { 1, 2, 0 }, p66.PlusOne(new int[] { 1, 1, 9 }));

        }

        [TestMethod]
        public void TestP55()
        {
            var p55 = new P55.Solution();

            Assert.IsTrue(p55.CanJump(new int[] { 2, 3, 1, 1, 4 }));
            Assert.IsFalse(p55.CanJump(new int[] { 3, 2, 1, 0, 4 }));

            Assert.IsFalse(p55.CanJump(
                new int[] {
                    2, 0, 6, 9, 8, 4, 5, 0, 8, 9,
                    1, 2, 9, 6, 8, 8, 0, 6, 3, 1,
                    2, 2, 1, 2, 6, 5, 3, 1, 2, 2,
                    6, 4, 2, 4, 3, 0, 0, 0, 3, 8,
                    2, 4, 0, 1, 2, 0, 1, 4, 6, 5,
                    8, 0, 7, 9, 3, 4, 6, 6, 5, 8,
                    9, 3, 4, 3, 7, 0, 4, 9, 0, 9,
                    8, 4, 3, 0, 7, 7, 1, 9, 1, 9,
                    4, 9, 0, 1, 9, 5, 7, 7, 1, 5,
                    8, 2, 8, 2, 6, 8, 2, 2, 7, 5,
                    1, 7, 9, 6 }));
        }

        [TestMethod]
        public void TestP56()
        {
            var p56 = new P56.Solution();
            var result = p56.Merge(new System.Collections.Generic.List<P56.Interval> { new P56.Interval(1, 3), new P56.Interval(2, 6), new P56.Interval(8, 10), new P56.Interval(15, 18) });

            Assert.AreEqual(3, result.Count);

            Assert.AreEqual(1, result[0].start);
            Assert.AreEqual(6, result[0].end);
            Assert.AreEqual(8, result[1].start);
            Assert.AreEqual(10, result[1].end);
            Assert.AreEqual(15, result[2].start);
            Assert.AreEqual(18, result[2].end);

        }

        [TestMethod]
        public void TestP62()
        {
            var p62 = new P62.Solution();
            Assert.AreEqual(1, p62.UniquePaths(1, 1));
            Assert.AreEqual(2, p62.UniquePaths(2, 2));

        }

        [TestMethod]
        public void TestP68()
        {
            var p68 = new P68.Solution();
            
            CollectionAssert.AreEqual(new string[] {  "This    is    an", "example  of text", "justification.  "}, p68.FullJustify(new string[] { "This", "is", "an", "example", "of", "text", "justification." }, 16).ToArray());
            CollectionAssert.AreEqual(new string[] { "What must be", "shall be.   " }, p68.FullJustify(new string[] { "What", "must", "be", "shall", "be." }, 12).ToArray());
            CollectionAssert.AreEqual(new string[] { "" }, p68.FullJustify(new string[] { "" }, 0).ToArray());
        }

        [TestMethod]
        public void TestP33()
        {
            var p33 = new P33.Solution();

            Assert.AreEqual(5, p33.Search(new int[] { 4, 5, 6, 7, 8, 0, 1, 2, 3 }, 0));
            Assert.AreEqual(4, p33.Search(new int[] { 2, 3, 4, -1, 0, 1 }, 0));
            Assert.AreEqual(-1, p33.Search(new int[] { 2, 3, 1 }, 0));
            Assert.AreEqual(2, p33.Search(new int[] { 2, 3, 1 }, 1));
            Assert.AreEqual(0, p33.Search(new int[] { 2, 3, 1 }, 2));
            Assert.AreEqual(1, p33.Search(new int[] { 2, 3, 4, 5, 6, 1 }, 3));
            Assert.AreEqual(-1, p33.Search(new int[] { 1, 3 }, 2));
            Assert.AreEqual(-1, p33.Search(new int[] { 1, 3 }, 0));
            Assert.AreEqual(0, p33.Search(new int[] { 1, 3 }, 1));
            Assert.AreEqual(-1, p33.Search(new int[] { 3, 1 }, 0));
            Assert.AreEqual(1, p33.Search(new int[] { 3, 1 }, 1));
            Assert.AreEqual(3, p33.Search(new int[] { 7, 8, 1, 2, 3, 4, 5, 6 }, 2));

        }
        
        [TestMethod]
        public void TestP166()
        {
            var solution = new P166.Solution();
            Assert.AreEqual("0", solution.FractionToDecimal(0, 1));
            Assert.AreEqual("-0.5", solution.FractionToDecimal(1, -2));
            Assert.AreEqual("0.(3)", solution.FractionToDecimal(1, 3));
            Assert.AreEqual("0.1(6)", solution.FractionToDecimal(1, 6));
            Assert.AreEqual("0.(142857)", solution.FractionToDecimal(1, 7));
            Assert.AreEqual("-1.(1)", solution.FractionToDecimal(-10, 9));
            Assert.AreEqual("0.39(285714)", solution.FractionToDecimal(11, 28));
            Assert.AreEqual("-2147483648", solution.FractionToDecimal(-2147483648, 1));
        }

        [TestMethod]
        public void TestP517()
        {
            var solution = new P517.Solution();

            Assert.AreEqual(3, solution.FindMinMoves(new int[] { 1, 0, 5 }));
            Assert.AreEqual(2, solution.FindMinMoves(new int[] { 0, 3, 0 }));
            Assert.AreEqual(2, solution.FindMinMoves(new int[] { 4, 0, 0, 4 }));

        }

        [TestMethod] 
        public void TestP483()
        {
            var solution = new P483.Solution();
            Assert.AreEqual("2", solution.SmallestGoodBase("3"));
            Assert.AreEqual("6903", solution.SmallestGoodBase("6904"));
            Assert.AreEqual("821424692950225217", solution.SmallestGoodBase("821424692950225218"));
            Assert.AreEqual("8", solution.SmallestGoodBase("4681"));
            Assert.AreEqual("999999999999999999", solution.SmallestGoodBase("1000000000000000000"));
        }

        [TestMethod]
        public void TestP273()
        {
            var solution = new P273.Solution();
            Assert.AreEqual("Zero", solution.NumberToWords(0));
            Assert.AreEqual("One", solution.NumberToWords(1));
            Assert.AreEqual("Nine", solution.NumberToWords(9));
            Assert.AreEqual("Ten", solution.NumberToWords(10));
            Assert.AreEqual("Nineteen", solution.NumberToWords(19));
            Assert.AreEqual("Twenty", solution.NumberToWords(20));
            Assert.AreEqual("Twenty Nine", solution.NumberToWords(29));
            Assert.AreEqual("Ninety", solution.NumberToWords(90));
            Assert.AreEqual("One Hundred", solution.NumberToWords(100));
            Assert.AreEqual("One Hundred One", solution.NumberToWords(101));
            Assert.AreEqual("Nine Hundred Ninety Nine", solution.NumberToWords(999));
            Assert.AreEqual("Nine Thousand", solution.NumberToWords(9000));
            Assert.AreEqual("Eight Million", solution.NumberToWords(8000000));
            Assert.AreEqual("Two Billion", solution.NumberToWords(2000000000));
            Assert.AreEqual("Two Billion One Million Three Thousand Four", solution.NumberToWords(2001003004));
            Assert.AreEqual("Nine Thousand One", solution.NumberToWords(9001));
            Assert.AreEqual("Twelve Thousand Three Hundred Forty Five", solution.NumberToWords(12345));
            Assert.AreEqual("One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven", solution.NumberToWords(1234567));
            
            Assert.AreEqual("Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred Forty Seven", solution.NumberToWords(2147483647));

        }

        [TestMethod]
        public void TestP135()
        {
            var solution = new P135.Solution();
            Assert.AreEqual(0, solution.Candy(new int[] { }));
            Assert.AreEqual(1, solution.Candy(new int[] { 1 }));
            Assert.AreEqual(2, solution.Candy(new int[] { 1, 1 }));
            Assert.AreEqual(3, solution.Candy(new int[] { 1, 1, 1 }));
            Assert.AreEqual(3, solution.Candy(new int[] { 1, 4 }));
            Assert.AreEqual(5, solution.Candy(new int[] { 1, -1, 1 }));
            Assert.AreEqual(9, solution.Candy(new int[] { 1, 2, 4, 4, 3 }));
            Assert.AreEqual(9, solution.Candy(new int[] { 4, 2, 3, 4, 1 }));
        }

        [TestMethod]
        public void TestP460()
        {
            var cache = new P460.LFUCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(1, cache.Get(1));       // returns 1
            cache.Put(3, 3);    // evicts key 2
            Assert.AreEqual(-1, cache.Get(2));       // returns -1 (not found)
            Assert.AreEqual(3, cache.Get(3));       // returns 3.
            cache.Put(4, 4);    // evicts key 1.
            Assert.AreEqual(-1, cache.Get(1));       // returns -1 (not found)
            Assert.AreEqual(3, cache.Get(3));       // returns 3
            Assert.AreEqual(4, cache.Get(4));       // returns 4

            cache = new P460.LFUCache(1);
            cache.Put(2, 1);
            Assert.AreEqual(1, cache.Get(2));
            cache.Put(3, 2);
            Assert.AreEqual(-1, cache.Get(2));
            Assert.AreEqual(2, cache.Get(3));

            cache = new P460.LFUCache(3);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(3, 3);
            cache.Put(4, 4);
            Assert.AreEqual(4, cache.Get(4));
            Assert.AreEqual(3, cache.Get(3));
            Assert.AreEqual(2, cache.Get(2));
            Assert.AreEqual(-1, cache.Get(1));
            cache.Put(5, 5);
            Assert.AreEqual(-1, cache.Get(1));
            Assert.AreEqual(2, cache.Get(2));
            Assert.AreEqual(3, cache.Get(3));
            Assert.AreEqual(-1, cache.Get(4));
            Assert.AreEqual(5, cache.Get(5));

        }

        [TestMethod]
        public void TestP460S2()
        {
            var cache = new P460.S2.LFUCache(3);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(3, 3);
            cache.Put(4, 4);
            Assert.AreEqual(4, cache.Get(4));
            Assert.AreEqual(3, cache.Get(3));
            Assert.AreEqual(2, cache.Get(2));
            Assert.AreEqual(-1, cache.Get(1));
            cache.Put(5, 5);
            Assert.AreEqual(-1, cache.Get(1));
            Assert.AreEqual(2, cache.Get(2));
            Assert.AreEqual(3, cache.Get(3));
            Assert.AreEqual(-1, cache.Get(4));
            Assert.AreEqual(5, cache.Get(5));
        }

        [TestMethod]
        public void TestP97()
        {
            var solution = new P97.Solution();
            Assert.IsTrue(solution.IsInterleave("aabcc", "dbbca", "aadbbcbcac"));
            Assert.IsFalse(solution.IsInterleave("aabcc", "dbbca", "aadbbbaccc"));

            var s1 = "bbbbbabbbbabaababaaaabbababbaaabbabbaaabaaaaababbbababbbbbabbbbababbabaabababbbaabababababbbaaababaa";
            var s2 = "babaaaabbababbbabbbbaabaabbaabbbbaabaaabaababaaaabaaabbaaabaaaabaabaabbbbbbbbbbbabaaabbababbabbabaab";
            var s3 = "babbbabbbaaabbababbbbababaabbabaabaaabbbbabbbaaabbbaaaaabbbbaabbaaabababbaaaaaabababbababaababbababbbababbbbaaaabaabbabbaaaaabbabbaaaabbbaabaaabaababaababbaaabbbbbabbbbaabbabaabbbbabaaabbababbabbabbab";
            Assert.IsFalse(solution.IsInterleave(s1, s2, s3));
        }

        [TestMethod]
        public void TestP14()
        {
            var solution = new P14.Solution();
            Assert.AreEqual("c", solution.LongestCommonPrefix(new string[] { "c", "c" }));
        }


        [TestMethod]
        public void TestP739()
        {
            var solution = new P739.Solution();
            CollectionAssert.AreEqual(new int[] { }, solution.DailyTemperatures(new int[] { }));
            CollectionAssert.AreEqual(new int[] { 1, 1, 4, 2, 1, 1, 0, 0 }, solution.DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }));
        }

        [TestMethod]
        public void TestP500()
        {
            var solution = new P500.Solution();
            CollectionAssert.AreEqual(new string[] { "Alaska", "Dad" }, solution.FindWords(new string[] { "Hello", "Alaska", "Dad", "Peace" }));
        }

        [TestMethod]
        public void TestP315()
        {
            var solution = new P315.Solution();
            CollectionAssert.AreEqual(new int[] { 2, 1, 1, 0 }, solution.CountSmaller(new int[] { 5, 2, 6, 1 }).ToArray());
            CollectionAssert.AreEqual(new int[] { 2, 1, 2, 0, 1, 0 }, solution.CountSmaller(new int[] { 5, 2, 6, 1, 6, 5 }).ToArray());
            CollectionAssert.AreEqual(new int[] { 2, 0, 0 }, solution.CountSmaller(new int[] { 2, 0, 1 }).ToArray());
        }

        [TestMethod]
        public void TestP134()
        {
            var solution = new P134.Solution();
            Assert.AreEqual(1, solution.CanCompleteCircuit(new int[] { 1, 4, 3 }, new int[] { 3, 1, 4 }));
        }

    }
}