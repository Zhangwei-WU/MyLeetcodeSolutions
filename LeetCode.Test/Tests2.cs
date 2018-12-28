
namespace LeetCode.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    
    public partial class Tests
    {
        [TestMethod]
        public void TestP3()
        {
            var solution = new P3.Solution();

            Assert.AreEqual(1, solution.LengthOfLongestSubstring("a"));
            Assert.AreEqual(2, solution.LengthOfLongestSubstring("abb"));
            Assert.AreEqual(3, solution.LengthOfLongestSubstring("dvdf"));
            Assert.AreEqual(4, solution.LengthOfLongestSubstring("abbabcda"));
        }

        [TestMethod]
        public void TestP42()
        {
            var solution = new P42.Solution();
            Assert.AreEqual(6, solution.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        }

        [TestMethod]
        public void TestP23()
        {
            var array1 = new int[] { 1, 4, 6 };
            var array2 = new int[] {  3, 5 };
            var array3 = new int[] { 2, 7, 8 };

            var lists = new P23.ListNode[] { GetListNode(array1), GetListNode(array2), GetListNode(array3) };

            var solution = new P23.Solution();
            var result = solution.MergeKLists(lists);

            Assert.AreEqual(1, result.val);
            result = result.next;
            Assert.AreEqual(2, result.val);
            result = result.next;
            Assert.AreEqual(3, result.val);
            result = result.next;
            Assert.AreEqual(4, result.val);
            result = result.next;
            Assert.AreEqual(5, result.val);
            result = result.next;
            Assert.AreEqual(6, result.val);
            result = result.next;
            Assert.AreEqual(7, result.val);
            result = result.next;
            Assert.AreEqual(8, result.val);
            result = result.next;
            Assert.IsNull(result);

        }

        private P23.ListNode GetListNode(int[] array)
        {
            var root = new P23.ListNode(array[0]);
            var curr = root;

            for(var i =1; i< array.Length; i++)
            {
                curr.next = new P23.ListNode(array[i]);
                curr = curr.next;
            }

            return root;
        }

        [TestMethod]
        public void TestP728()
        {
            var solution = new P728.Solution();
            CollectionAssert.AreEqual(new int[] { }, solution.SelfDividingNumbers(13, 13).ToArray());
            CollectionAssert.AreEqual(new int[] { 15 }, solution.SelfDividingNumbers(13, 15).ToArray());
        }


        [TestMethod]
        public void TestP149()
        {
            var solution = new P149.Solution();
            Assert.AreEqual(1, solution.MaxPoints(new P149.Point[] { new P149.Point(0, 0) }));
            Assert.AreEqual(2, solution.MaxPoints(new P149.Point[] { new P149.Point(0, 0), new P149.Point(1, 1) }));
            Assert.AreEqual(3, solution.MaxPoints(new P149.Point[] { new P149.Point(0, 0), new P149.Point(1, 1), new P149.Point(-1, -1) }));
            Assert.AreEqual(3, solution.MaxPoints(new P149.Point[] { new P149.Point(0, 0), new P149.Point(1, 1), new P149.Point(0, 0) }));
            Assert.AreEqual(2, solution.MaxPoints(new P149.Point[] { new P149.Point(0, 0), new P149.Point(1, 1), new P149.Point(-1, 1) }));
            Assert.AreEqual(3, solution.MaxPoints(new P149.Point[] { new P149.Point(0, 0), new P149.Point(0, 0), new P149.Point(0, 0) }));
            Assert.AreEqual(3, solution.MaxPoints(new P149.Point[] { new P149.Point(0, 0), new P149.Point(0, -1), new P149.Point(0, 1) }));
            Assert.AreEqual(2, solution.MaxPoints(new P149.Point[] { new P149.Point(0, 0), new P149.Point(94911151, 94911150), new P149.Point(94911152, 94911151) }));
        }

        [TestMethod]
        public void TestP146()
        {
            var cache = new P146.LRUCache(2 /* capacity */ );

            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(1, cache.Get(1));       // returns 1
            cache.Put(3, 3);    // evicts key 2
            Assert.AreEqual(-1, cache.Get(2));       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            Assert.AreEqual(-1, cache.Get(1));       // returns -1 (not found)
            Assert.AreEqual(3, cache.Get(3));       // returns 3
            Assert.AreEqual(4, cache.Get(4));       // returns 4

        }

        [TestMethod]
        public void TestP745()
        {
            var solution = new P745.WordFilter(new string[] { "apple", "apple", "appae" });
            Assert.AreEqual(2, solution.F("a", "e"));
            Assert.AreEqual(-1, solution.F("", "b"));

            solution = new P745.WordFilter(new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" });
            Assert.AreEqual(5, solution.F("", "abaa"));
            Assert.AreEqual(7, solution.F("babbab", ""));
            Assert.AreEqual(2, solution.F("ab", "baaa"));
            Assert.AreEqual(1, solution.F("baaabba", "b"));
            Assert.AreEqual(5, solution.F("abab", "abbaabaa"));
            Assert.AreEqual(5, solution.F("", "aa"));
            Assert.AreEqual(3, solution.F("", "bba"));
            Assert.AreEqual(6, solution.F("", "baaaaabbbb"));
            Assert.AreEqual(6, solution.F("ba", "aabbbb"));
            Assert.AreEqual(1, solution.F("baaa", "aabbabbb"));
        }

        [TestMethod]
        public void TestP329()
        {
            var solution = new P329.Solution();
            solution.LongestIncreasingPath(new int[,] { { 9, 9, 4 }, { 6, 6, 8 }, { 2, 1, 1 } });
        }

        [TestMethod]
        public void TestP20()
        {
            var solution = new P20.Solution();
            Assert.IsTrue(solution.IsValid("()"));
            Assert.IsTrue(solution.IsValid("[]{}()"));
            Assert.IsFalse(solution.IsValid("[}"));
            Assert.IsFalse(solution.IsValid("[{(]"));
            Assert.IsTrue(solution.IsValid("{[((())())]()}"));
            Assert.IsFalse(solution.IsValid("((((((()))))"));
        }

        [TestMethod]
        public void TestP5()
        {
            var solution = new P5.Solution();

            Assert.AreEqual("bb", solution.LongestPalindrome("cbbd"));
            Assert.AreEqual("aba", solution.LongestPalindrome("abac"));
            Assert.AreEqual("bbbbbbb", solution.LongestPalindrome("bbbbbbb"));
            Assert.AreEqual("bccb", solution.LongestPalindrome("abccbdefgf"));
            Assert.AreEqual("a", solution.LongestPalindrome("abcda"));
            Assert.AreEqual("adada", solution.LongestPalindrome("babadada"));
        }

        [TestMethod]
        public void TestP2()
        {
            var solution = new P2.Solution();

            var result = solution.AddTwoNumbers(new P2.ListNode(0), new P2.ListNode(0));
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.val);
            result = result.next;
            Assert.IsNull(result);

            result = solution.AddTwoNumbers(new P2.ListNode(2), new P2.ListNode(1));
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.val);
            result = result.next;
            Assert.IsNull(result);

            result = solution.AddTwoNumbers(new P2.ListNode(7), new P2.ListNode(8));
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.val);
            result = result.next;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.val);
            result = result.next;
            Assert.IsNull(result);

            result = solution.AddTwoNumbers(new P2.ListNode(1) { next = new P2.ListNode(1) }, new P2.ListNode(2) { next = new P2.ListNode(9) });
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.val);
            result = result.next;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.val);
            result = result.next;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.val);
            result = result.next;
            Assert.IsNull(result);
        }

        private char[,] ConvertTo2DArray(string data)
        {
            var arr = data.Split('\t');
            var x = arr[0].Length;
            var y = arr.Length;

            var result = new char[x, y];
            for (var i = 0; i < x; i++) for (var j = 0; j < y; j++) result[i, j] = arr[j][i];
            return result;
        }

        [TestMethod]
        public void TestP200()
        {
            var solution = new P200.Solution();
            Assert.AreEqual(1, solution.NumIslands(ConvertTo2DArray("11110\t11010\t11000\t00000")));
            Assert.AreEqual(3, solution.NumIslands(ConvertTo2DArray("11000\t11000\t00100\t00011")));
            Assert.AreEqual(0, solution.NumIslands(ConvertTo2DArray("0")));
            Assert.AreEqual(2, solution.NumIslands(ConvertTo2DArray("10\t01")));

        }
    }
}
