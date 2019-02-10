﻿namespace LeetCode.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public partial class Tests
    {
        [TestMethod]
        public void TestP393()
        {
            var solution = new P393.Solution();
            Assert.IsTrue(solution.ValidUtf8(new int[] { 230, 136, 145 }));
        }

        [TestMethod]
        public void TestP560()
        {
            var solution = new P560.Solution();
            Assert.AreEqual(2, solution.SubarraySum(new int[] { 1, 1, 1 }, 2));
        }

        [TestMethod]
        public void TestP151()
        {
            var solution = new P151.Solution();
            Assert.AreEqual("blue is sky the", solution.ReverseWords("the sky is blue"));
            Assert.AreEqual("blue is sky the", solution.ReverseWords("    the sky is   blue   "));
            Assert.AreEqual("abc", solution.ReverseWords("abc"));
            Assert.AreEqual("", solution.ReverseWords(""));
            Assert.AreEqual("", solution.ReverseWords(" "));
            Assert.AreEqual("", solution.ReverseWords("     "));
            Assert.AreEqual("a", solution.ReverseWords("     a"));
        }

        [TestMethod]
        public void TestP722()
        {
            var solution = new P722.Solution();

            CollectionAssert.AreEqual(
                new string[] { "int main()", "{ ", "  ", "int a, b, c;", "a = b + c;", "}" },
                solution.RemoveComments(
                    new string[] {
                        "/*Test program */",
                        "int main()",
                        "{ ",
                        "  // variable declaration ",
                        "int a, b, c;",
                        "/* This is a test",
                        "   multiline  ",
                        "   comment for ",
                        "   testing */",
                        "a = b + c;", "}" }).ToArray());

            CollectionAssert.AreEqual(
                new string[] { "main() {", "   double s = 33;", "   cout << s;", "}" },
                solution.RemoveComments(
                    new string[] { "main() {", "/* here is commments", "  // still comments */", "   double s = 33;", "   cout << s;", "}" }).ToArray());

            CollectionAssert.AreEqual(
                new string[] { "a", "blank", "d/f" },
                solution.RemoveComments(
                    new string[] { "a//*b//*c", "blank", "d/*/e*//f" }).ToArray());

            CollectionAssert.AreEqual(
                new string[] { "ab" },
                solution.RemoveComments(
                    new string[] { "a/*comment", "line", "more_comment*/b" }).ToArray());

        }

        [TestMethod]
        public void TestP93()
        {
            var solution = new P93.Solution();

            CollectionAssert.AreEquivalent(
                new string[] { "255.255.11.135", "255.255.111.35" },
                solution.RestoreIpAddresses("25525511135").ToArray());
        }

        [TestMethod]
        public void TestP41()
        {
            var solution = new P41.Solution();

            Assert.AreEqual(3, solution.FirstMissingPositive(new int[] { 1, 2, 0 }));
            Assert.AreEqual(2, solution.FirstMissingPositive(new int[] { 3, 4, -1, 1 }));
            Assert.AreEqual(1, solution.FirstMissingPositive(new int[] { 7, 8, 9, 11, 12 }));
        }

        [TestMethod]
        public void TestP127()
        {
            var solution = new P127.Solution();

            Assert.AreEqual(5, solution.LadderLength("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }));
        }

        [TestMethod]
        public void TestP215()
        {
            var solution = new P215.Solution();
            Assert.AreEqual(5, solution.FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2));
            Assert.AreEqual(4, solution.FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
        }

        [TestMethod]
        public void TestP43()
        {
            var solution = new P43.Solution();
            Assert.AreEqual("6", solution.Multiply("2", "3"));
            Assert.AreEqual("56088", solution.Multiply("123", "456"));
        }

        [TestMethod]
        public void TestP67()
        {
            var solution = new P67.Solution();
            Assert.AreEqual("0", solution.AddBinary("0", "0"));
            Assert.AreEqual("1", solution.AddBinary("1", "0"));
            Assert.AreEqual("10", solution.AddBinary("1", "1"));
            Assert.AreEqual("1001", solution.AddBinary("111", "10"));
            Assert.AreEqual("1110", solution.AddBinary("111", "111"));
        }

        [TestMethod]
        public void TestP224()
        {
            var solution = new P224.Solution();
            Assert.AreEqual(2, solution.Calculate("1 + 1  "));
            Assert.AreEqual(23, solution.Calculate("2-1 + 22  "));
            Assert.AreEqual(23, solution.Calculate("(1+(4+5+2)-3)+(6+8)"));
        }

        [TestMethod]
        public void TestP528()
        {
            var solution = new P528.Solution(new int[] { 2, 3 });
            var counter = new int[2];
            for (var i = 0; i < 10000; i++)
            {
                var idx = solution.PickIndex();
                Assert.IsTrue(idx >= 0 && idx < 2);
                counter[idx]++;
            }

            Assert.IsTrue(counter[0] >= 4000 - 500 && counter[0] <= 4000 + 500);
        }

        [TestMethod]
        public void TestP829()
        {
            var solution = new P829.Solution();
            Assert.AreEqual(2, solution.ConsecutiveNumbersSum(5));
            Assert.AreEqual(3, solution.ConsecutiveNumbersSum(9));
            Assert.AreEqual(4, solution.ConsecutiveNumbersSum(15));
        }


        [TestMethod]
        public void TestP295()
        {
            var solution = new P295.MedianFinder();
            solution.AddNum(1);
            Assert.AreEqual(1.0d, solution.FindMedian());
            solution.AddNum(2);
            Assert.AreEqual(1.5d, solution.FindMedian());
            solution.AddNum(3);
            Assert.AreEqual(2.0d, solution.FindMedian());
            solution.AddNum(0);
            Assert.AreEqual(1.5d, solution.FindMedian());

            solution = new P295.MedianFinder();
            solution.AddNum(12);
            Assert.AreEqual(12.0d, solution.FindMedian());
            solution.AddNum(10);
            Assert.AreEqual(11.0d, solution.FindMedian());
            solution.AddNum(13);
            Assert.AreEqual(12.0d, solution.FindMedian());
        }

        [TestMethod]
        public void TestP621()
        {
            var solution = new P621.Solution();
            Assert.AreEqual(8, solution.LeastInterval("AAABBB".ToArray(), 2));
            Assert.AreEqual(16, solution.LeastInterval("AAAAAABCDEFG".ToArray(), 2));
            //
            Assert.AreEqual(1000, solution.LeastInterval("GCAHAGGFGJHCAGEAHEFDBDHHEGFBCGFHJFACGDIJAGDFBFHIGJGHFEHJCEHFCEFHHIGAGDCBIDBCJIBGCHDIABAJCEBFBJJDDHIIBAEHJJAJEHGBFCHCBJBAHBDIFAEJHCEGFGBGCGAHEFHFCGBIEBJDBBGCAJBJJFJCAGJEGJCDDAIAJFHJDDDCEDDFBAJDIHBAFEBJAHDEIBHCCCGCBEAGHHAIABADAIECCDABHDECAHBIABEHCBADHEJBJABGJJFFHIAHFCHDHCCEIGJHDEIJCCHJCGIEDEHJAHDABFIFJJHDICGJCCDBEBEBGBACFEHBDCHFAIAEJFAEBIGHDBFDBIBEDIDFAEHBIGFDEBECCCJJCHIBHFHFDJDDHHCDAJDFDGBIFJJCCIFGFCEGEFDAIIHGHHAJDJGFGEEAHBGAJJEIHAGECDIBEAGACEBJCBADJEJIFFCBIHCFBCGDAABFCDBIIHHJAFJFJFHGFDJGIEBCGIFFJHHGAAJCGFBAAEEAEIGFDBIFABJFFJBFJFJFIEJHDGGDFGBJFJAJEGHIEGDIBDJAAGAIIAAIIHECAGIFFCDJJIAAFCJGCCHEAHFBJGIAAHGBEGDICGJCCIHBDJHBJHBFJEJAGHBEHBFFHEBEGHJGJBHCHAABEIHBIDJJCDGIJGJDFJEFDEBDBCBBCCIFDEIGGIBHGJAAHIIHAIFCDACGEGEEHDCGDIAGGDAHHIFEIADHBBGICGBIIDFFCCAIEAEJAHCDACBGHGJGIHBACHIDDCFGBHEBBHCBGGCFBEJBBIDHDIIAAHGFBJFDEGFAGGDABBBJAFHHDCJIAHGCJIFJCAECHJHHFGEACFJHDGGDDCBHBCEFBDJHJJJAFFDEFCIBHHDEAIABFGFFIEEGAIDFCHECGHFFHJHGAEHBGGDDDFIAFFDEHJEDDAJFEEEFIDAFFJEIJDDGACGGIEGEHEDEJBGIJCHCCAABCGBDIDEHJJBFEJHHIGBD".ToArray(),
                1));
        }

        [TestMethod]
        public void TestP289()
        {
            var solution = new P289.Solution();
        }

        [TestMethod]
        public void TestP239()
        {
            var solution = new P239.Solution();
            CollectionAssert.AreEqual(
                new int[] { 3, 3, 5, 5, 6, 7 },
                solution.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3));

        }

        [TestMethod]
        public void TestP16()
        {
            var solution = new P16.Solution();
            Assert.AreEqual(2, solution.ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1));
        }

        [TestMethod]
        public void TestP128()
        {
            var s1 = new P128.S1.Solution();
            Assert.AreEqual(4, s1.LongestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }));

            var s2 = new P128.S2.Solution();
            Assert.AreEqual(4, s2.LongestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }));
        }

        private P25.ListNode GetP25ListNode(int[] array)
        {
            var root = new P25.ListNode(array[0]);
            var curr = root;

            for (var i = 1; i < array.Length; i++)
            {
                curr.next = new P25.ListNode(array[i]);
                curr = curr.next;
            }

            return root;
        }

        private int[] GetArray(P25.ListNode node)
        {
            List<int> result = new List<int>();
            while (node != null)
            {
                result.Add(node.val);
                node = node.next;
            }

            return result.ToArray();
        }

        [TestMethod]
        public void TestP25()
        {
            var solution = new P25.Solution();
            CollectionAssert.AreEqual(
                new int[] { 2, 1, 4, 3, 5 },
                GetArray(solution.ReverseKGroup(GetP25ListNode(new int[] { 1, 2, 3, 4, 5 }), 2)));
        }

        [TestMethod]
        public void TestP857()
        {
            var solution = new P857.Solution();
            Assert.AreEqual(399.53846d,
                (int)(100000 *
                solution.MincostToHireWorkers(
                    new int[] { 14, 56, 59, 89, 39, 26, 86, 76, 3, 36 },
                    new int[] { 90, 217, 301, 202, 294, 445, 473, 245, 415, 487 },
                    2)) / 100000.0d);

            Assert.AreEqual(105.0d, solution.MincostToHireWorkers(new int[] { 10, 20, 5 }, new int[] { 70, 50, 30 }, 2));
            Assert.AreEqual(30.66666d, (int)(100000 *
                solution.MincostToHireWorkers(
                    new int[] { 3, 1, 10, 10, 1 },
                    new int[] { 4, 8, 2, 2, 7 },
                    3)) / 100000.0d);
        }

        [TestMethod]
        public void TestP85()
        {
            var solution = new P85.S2.Solution();
            Assert.AreEqual(6, solution.MaximalRectangle(new char[4, 5]
            { { '1', '0', '1', '0', '0' },
              { '1', '0', '1', '1', '1' },
              { '1', '1', '1', '1', '1' },
              { '1', '0', '0', '1', '0' } }));
        }

        [TestMethod]
        public void TestP343()
        {
            var solution = new P343.Solution();

            Assert.AreEqual(36, solution.IntegerBreak(10));
            Assert.AreEqual(18, solution.IntegerBreak(8));
            Assert.AreEqual(27, solution.IntegerBreak(9));
            Assert.AreEqual(1, solution.IntegerBreak(2));
        }

        [TestMethod]
        public void TestP34()
        {
            var solution = new P34.Solution();

            CollectionAssert.AreEqual(new int[] { 3, 4 }, solution.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8));
            CollectionAssert.AreEqual(new int[] { -1, -1 }, solution.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6));
            CollectionAssert.AreEqual(new int[] { 0, 0 }, solution.SearchRange(new int[] { 1 }, 1));
            CollectionAssert.AreEqual(new int[] { 0, 1 }, solution.SearchRange(new int[] { 1, 1 }, 1));
            CollectionAssert.AreEqual(new int[] { 0, 0 }, solution.SearchRange(new int[] { 1, 2, 3 }, 1));
            CollectionAssert.AreEqual(new int[] { 2, 2 }, solution.SearchRange(new int[] { 1, 2, 3 }, 3));
            CollectionAssert.AreEqual(new int[] { 0, 4 }, solution.SearchRange(new int[] { 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 }, 0));
        }

        [TestMethod]
        public void TestP30()
        {
            var solution = new P30.Solution();
            CollectionAssert.AreEquivalent(
                new int[] { 0, 9 },
                solution.FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" }).ToArray());

            CollectionAssert.AreEquivalent(
               new int[] { },
               solution.FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" }).ToArray());

            CollectionAssert.AreEquivalent(
               new int[] { 8 },
               solution.FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "good" }).ToArray());
        }

        [TestMethod]
        public void TestP32()
        {
            var solution = new P32.Solution();
            Assert.AreEqual(2, solution.LongestValidParentheses("(()"));
            Assert.AreEqual(4, solution.LongestValidParentheses(")()())"));
        }

        [TestMethod]
        public void TestP218()
        {
            var solution = new P218.Solution();


        }

        [TestMethod]
        public void TestP264()
        {
            var solution = new P264.Solution();
            Assert.AreEqual(1, solution.NthUglyNumber(1));
            Assert.AreEqual(2, solution.NthUglyNumber(2));
            Assert.AreEqual(3, solution.NthUglyNumber(3));
            Assert.AreEqual(4, solution.NthUglyNumber(4));
            Assert.AreEqual(5, solution.NthUglyNumber(5));
            Assert.AreEqual(6, solution.NthUglyNumber(6));
            Assert.AreEqual(8, solution.NthUglyNumber(7));
            Assert.AreEqual(10, solution.NthUglyNumber(9));
            Assert.AreEqual(12, solution.NthUglyNumber(10));
        }

        [TestMethod]
        public void TestP313()
        {
            var solution = new P313.Solution();
            Assert.AreEqual(12, solution.NthSuperUglyNumber(10, new int[] { 2, 3, 5 }));
            Assert.AreEqual(1092889481, solution.NthSuperUglyNumber(100000, new int[] { 7, 19, 29, 37, 41, 47, 53, 59, 61, 79, 83, 89, 101, 103, 109, 127, 131, 137, 139, 157, 167, 179, 181, 199, 211, 229, 233, 239, 241, 251 }));
        }

        [TestMethod]
        public void TestP373()
        {
            var solution = new P373.Solution();
            solution.KSmallestPairs(new int[] { 1, 7, 11 }, new int[] { 2, 4, 6 }, 3);
        }

        [TestMethod]
        public void TestP84()
        {
            var solution = new P84.Solution();
            Assert.AreEqual(10, solution.LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 }));
        }

        [TestMethod]
        public void TestP71()
        {
            var solution = new P71.Solution();
            Assert.AreEqual("/home", solution.SimplifyPath("/home/"));
            Assert.AreEqual("/", solution.SimplifyPath("/../"));
            Assert.AreEqual("/home/foo", solution.SimplifyPath("/home//foo/"));
            Assert.AreEqual("/c", solution.SimplifyPath("/a/./b/../../c/"));
            Assert.AreEqual("/c", solution.SimplifyPath("/a/../../b/../c//.//"));
            Assert.AreEqual("/a/b/c", solution.SimplifyPath("/a//b////c/d//././/.."));
        }

        [TestMethod]
        public void TestP75()
        {
            var solution = new P75.Solution();
            var source = new int[] { 2, 0, 2, 1, 1, 0 };
            var expected = source.OrderBy(p => p).ToArray();
            solution.SortColors(source);
            CollectionAssert.AreEqual(expected, source);
        }

        [TestMethod]
        public void TestP233()
        {
            var solution = new P233.Solution();
            Assert.AreEqual(6, solution.CountDigitOne(13));
            Assert.AreEqual(1, solution.CountDigitOne(9));
            Assert.AreEqual(20, solution.CountDigitOne(99));
            Assert.AreEqual(300, solution.CountDigitOne(999));
            Assert.AreEqual(4000, solution.CountDigitOne(9999));
            Assert.AreEqual(50000, solution.CountDigitOne(99999));
            Assert.AreEqual(600000, solution.CountDigitOne(999999));
            Assert.AreEqual(7000000, solution.CountDigitOne(9999999));
            Assert.AreEqual(80000000, solution.CountDigitOne(99999999));
            Assert.AreEqual(900000000, solution.CountDigitOne(999999999));
        }

        [TestMethod]
        public void TestP233S2()
        {
            var solution = new P233.S2.Solution();
            Assert.AreEqual(6, solution.CountDigitOne(13));
            Assert.AreEqual(1, solution.CountDigitOne(9));
            Assert.AreEqual(20, solution.CountDigitOne(99));
            Assert.AreEqual(300, solution.CountDigitOne(999));
            Assert.AreEqual(4000, solution.CountDigitOne(9999));
            Assert.AreEqual(50000, solution.CountDigitOne(99999));
            Assert.AreEqual(600000, solution.CountDigitOne(999999));
            Assert.AreEqual(7000000, solution.CountDigitOne(9999999));
            Assert.AreEqual(80000000, solution.CountDigitOne(99999999));
            Assert.AreEqual(900000000, solution.CountDigitOne(999999999));
        }
    }
}
