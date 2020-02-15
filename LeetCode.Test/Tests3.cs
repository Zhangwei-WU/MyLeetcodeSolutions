namespace LeetCode.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using LeetCode.Generics;

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

        private ListNode GetP25ListNode(int[] array)
        {
            var root = new ListNode(array[0]);
            var curr = root;

            for (var i = 1; i < array.Length; i++)
            {
                curr.next = new ListNode(array[i]);
                curr = curr.next;
            }

            return root;
        }

        private int[] GetArray(ListNode node)
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

        [TestMethod]
        public void TestP279()
        {
            var solution = new P279.Solution();

            Assert.AreEqual(3, solution.NumSquares(12));
            Assert.AreEqual(2, solution.NumSquares(13));
            Assert.AreEqual(1, solution.NumSquares(1));
        }

        [TestMethod]
        public void TestP357()
        {
            var solution = new P357.Solution();
            Assert.AreEqual(1, solution.CountNumbersWithUniqueDigits(0));
            Assert.AreEqual(10, solution.CountNumbersWithUniqueDigits(1));
            Assert.AreEqual(91, solution.CountNumbersWithUniqueDigits(2));
        }

        [TestMethod]
        public void TestP844()
        {
            var solution = new P844.Solution();
            Assert.IsTrue(solution.BackspaceCompare("y#fo##f", "y#f#o##f"));
        }

        [TestMethod]
        public void TestP394()
        {
            var solution = new P394.Solution();
            Assert.AreEqual("aaabcbc", solution.DecodeString("3[a]2[bc]"));
            Assert.AreEqual("accaccacc", solution.DecodeString("3[a2[c]]"));
            Assert.AreEqual("abcabccdcdcdef", solution.DecodeString("2[abc]3[cd]ef"));
        }

        [TestMethod]
        public void TestP150()
        {
            var solution = new P150.Solution();
            Assert.AreEqual(9, solution.EvalRPN(new string[] { "2", "1", "+", "3", "*" }));
            Assert.AreEqual(6, solution.EvalRPN(new string[] { "4", "13", "5", "/", "+" }));
            Assert.AreEqual(22, solution.EvalRPN(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }));
        }

        [TestMethod]
        public void TestP69()
        {
            var solution = new P69.Solution();
            Assert.AreEqual(1, solution.MySqrt(1));
            Assert.AreEqual(1, solution.MySqrt(2));
            Assert.AreEqual(1, solution.MySqrt(3));
            Assert.AreEqual(2, solution.MySqrt(4));
            Assert.AreEqual(2, solution.MySqrt(7));
            Assert.AreEqual(3, solution.MySqrt(9));
            Assert.AreEqual(4, solution.MySqrt(16));
            Assert.AreEqual(5, solution.MySqrt(25));
            Assert.AreEqual(5, solution.MySqrt(30));
            Assert.AreEqual(6, solution.MySqrt(36));
            Assert.AreEqual(6, solution.MySqrt(40));
            Assert.AreEqual(7, solution.MySqrt(50));
            Assert.AreEqual(7, solution.MySqrt(60));
            Assert.AreEqual(9, solution.MySqrt(90));
            Assert.AreEqual(10, solution.MySqrt(101));
            Assert.AreEqual(46340, solution.MySqrt(2147395600));
        }

        [TestMethod]
        public void TestP65()
        {
            var solution = new P65.Solution();
            Assert.IsTrue(solution.IsNumber("0"));
            Assert.IsFalse(solution.IsNumber(" "));
            Assert.IsTrue(solution.IsNumber("01"));
            Assert.IsTrue(solution.IsNumber("3."));
            Assert.IsTrue(solution.IsNumber("2e0"));
        }

        [TestMethod]
        public void TestP187()
        {
            var solution = new P187.Solution();
            CollectionAssert.AreEquivalent(new string[] { "AAAAAAAAAA" }, solution.FindRepeatedDnaSequences("AAAAAAAAAAA").ToArray());
        }

        [TestMethod]
        public void TestP18()
        {
            var solution = new P18.Solution();
            var result = solution.FourSum(new int[] { 1, -2, -5, -4, -3, 4, 4, 5 }, -11);
        }

        [TestMethod]
        public void TestP131()
        {
            var solution = new P131.Solution();
            var result = solution.Partition("cdd");
            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new string[] { "c", "d", "d" }, result[0].ToArray());
            CollectionAssert.AreEqual(new string[] { "c", "dd" }, result[1].ToArray());
        }

        [TestMethod]
        public void TestP1282()
        {
            var sln = new P1282.Solution();
            var result = sln.GroupThePeople(new int[] { 3, 3, 3, 3, 3, 1, 3 });
        }

        [TestMethod]
        public void TestP1106()
        {
            var sln = new P1106.Solution();
            Assert.IsTrue(sln.ParseBoolExpr("!(f)"));
            Assert.IsTrue(sln.ParseBoolExpr("|(f,t)"));
            Assert.IsFalse(sln.ParseBoolExpr("&(t,f)"));
            Assert.IsFalse(sln.ParseBoolExpr("|(&(t,f,t),!(t))"));
        }

        [TestMethod]
        public void TestP639()
        {
            var sln = new P639.Solution();

            Assert.AreEqual(9, sln.NumDecodings("*"));
            Assert.AreEqual(18, sln.NumDecodings("1*"));
            Assert.AreEqual(404, sln.NumDecodings("*1*1*0"));
            Assert.AreEqual(123775776, sln.NumDecodings("********"));
        }

        [TestMethod]
        public void TestP57()
        {
            var sln = new P57.Solution();

            var result = sln.Insert(new int[][] { new int[]{ 1, 3 }, new int[] { 6, 9 } }, new int[] { 2, 5 });

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(5, result[0][1]);
            Assert.AreEqual(6, result[1][0]);
            Assert.AreEqual(9, result[1][1]);
        }

        [TestMethod]
        public void TestP648()
        {
            var sln = new P468.Solution();
            Assert.AreEqual("IPv4", sln.ValidIPAddress("172.16.254.1"));
            Assert.AreEqual("IPv6", sln.ValidIPAddress("2001:0db8:85a3:0:0:8A2E:0370:7334"));
            Assert.AreEqual("Neither", sln.ValidIPAddress("256.256.256.256"));
        }

        [TestMethod]
        public void TestP982()
        {
            var sln = new P982.Solution();
            Assert.AreEqual(12, sln.CountTriplets(new int[] { 2,1,3 }));
            Assert.AreEqual(14916, sln.CountTriplets(new int[] { 55340, 49673, 27562, 16968, 33506, 26537, 51367, 19877, 31234, 38232, 59514, 33075, 18470, 49532, 40525, 16417, 59621, 64407, 53098, 59124, 20325, 47830, 58906, 44825, 30942, 6599, 28453, 40035, 59835, 63347, 31261, 56708, 17071, 52758, 35959, 920, 47166, 26137, 54057, 43788, 74, 32347, 56859, 15984, 21312, 57047, 12521, 37192, 15637, 63408 }));
            Assert.AreEqual(113138322, sln.CountTriplets(new int[] { 41816, 11362, 40028, 40141, 46197, 33562, 18640, 57505, 23138, 30034, 41410, 33824, 62683, 62568, 60932, 61215, 38073, 32125, 46144, 14117, 17424, 2870, 10673, 253, 42901, 9201, 51555, 44597, 63614, 25985, 60384, 29733, 22249, 6706, 57857, 52087, 21163, 29867, 21308, 1889, 2906, 24163, 13735, 34374, 12306, 13213, 44083, 48208, 20462, 56360, 16688, 22540, 46693, 2916, 61222, 4740, 30207, 47487, 3110, 53018, 64152, 30180, 7741, 5339, 6470, 50163, 27132, 60242, 28877, 5055, 27979, 49468, 54351, 2578, 11821, 32113, 8394, 57087, 61240, 20945, 28497, 36507, 18710, 35459, 13184, 19440, 28952, 39627, 35138, 17104, 15190, 7781, 51347, 6481, 48030, 16303, 18648, 48239, 43228, 48622, 33769, 56301, 7981, 42283, 7749, 48318, 23521, 44229, 46103, 43293, 14520, 54512, 15737, 33957, 44213, 15309, 41190, 18797, 11231, 53067, 36249, 21488, 38366, 1657, 8508, 25924, 63947, 33454, 5010, 50137, 51212, 50777, 37322, 45593, 13989, 48009, 53488, 49805, 23164, 38733, 41221, 59035, 7078, 54652, 34500, 23502, 29858, 828, 14422, 42779, 43309, 32420, 62477, 31517, 20574, 55560, 16984, 39603, 46099, 53850, 51469, 25171, 3878, 2509, 47609, 63025, 22489, 28914, 47565, 43111, 17046, 44012, 19982, 23354, 35357, 47992, 9910, 1440, 41145, 1609, 2946, 14796, 42852, 4361, 4089, 63707, 27698, 58486, 14190, 28522, 23464, 11595, 21549, 64670, 48975, 25078, 26822, 17284, 34821, 48210, 45000, 30320, 2748, 60391, 26799, 25578, 203, 9058, 56941, 33681, 48000, 9710, 21630, 55059, 53782, 16173, 1440, 52852, 11065, 51621, 44804, 11030, 5143, 60794, 39182, 40665, 29983, 9835, 39450, 16546, 52815, 48019, 1786, 61107, 2380, 5873, 19184, 9883, 15476, 23318, 48201, 26523, 17684, 32264, 25728, 20366, 59017, 36074, 64050, 50653, 37388, 17199, 45012, 29879, 47276, 26462, 32506, 1355, 48493, 2246, 44612, 38142, 50850, 18990, 44964, 13572, 34686, 22300, 64123, 63692, 13695, 37095, 21590, 63474, 60589, 38413, 47191, 44651, 23157, 60054, 58946, 21670, 48981, 595, 53500, 37019, 62410, 23802, 41006, 21168, 51300, 39367, 64714, 66, 9224, 2857, 8247, 60908, 62167, 31484, 62042, 53633, 51027, 48973, 12298, 35971, 27779, 62245, 11392, 11131, 43179, 10315, 7212, 33025, 52209, 39652, 49463, 17416, 18675, 28095, 64936, 47049, 62013, 35249, 36343, 64886, 12451, 51287, 51872, 55360, 49155, 10179, 43327, 60535, 36915, 23654, 62227, 36804, 26977, 40247, 52699, 14962, 1028, 34674, 61692, 44581, 41347, 41144, 32570, 47901, 16331, 58442, 17987, 61927, 60718, 5106, 29371, 48761, 29468, 33351, 52876, 46202, 62783, 10779, 60526, 60816, 41598, 61629, 16560, 57788, 50690, 39956, 5939, 1974, 718, 16420, 49961, 25337, 50819, 41002, 25510, 57681, 2517, 30494, 54385, 8310, 46562, 21503, 1592, 31046, 34189, 2725, 37088, 22769, 294, 12502, 7262, 35430, 2825, 60826, 55381, 61951, 20630, 59327, 64507, 50117, 18027, 43967, 39037, 26489, 20060, 3922, 8217, 8778, 31515, 42067, 50073, 3061, 53985, 2848, 36368, 48768, 41367, 62238, 22590, 38396, 5426, 36686, 53300, 13212, 17102, 45901, 16638, 16989, 61309, 65440, 10171, 58993, 36223, 2529, 38371, 42044, 2214, 49656, 53595, 4695, 42493, 29920, 15644, 30059, 10445, 21867, 42939, 31226, 36432, 35615, 53778, 22503, 53278, 5242, 28031, 23089, 29594, 54624, 33580, 64700, 56456, 7788, 20767, 1489, 48087, 1258, 58060, 12670, 27121, 4065, 20398, 25527, 3423, 50302, 46619, 23454, 54735, 5073, 3539, 23263, 59103, 49575, 44061, 36879, 52675, 27015, 2011, 52586, 12484, 25405, 23436, 8084, 22989, 11605, 40371, 42823, 894, 29915, 36310, 57125, 32507, 5272, 3389, 56499, 51821, 56259, 17186, 42467, 6272, 54170, 21863, 62596, 30892, 2167, 59575, 40994, 18814, 2411, 24686, 10280, 35932, 9626, 11443, 60350, 41950, 15897, 57599, 40941, 61970, 31648, 58189, 44462, 2894, 15747, 18453, 11142, 15609, 14813, 57563, 30336, 57443, 9043, 37022, 882, 60968, 369, 25552, 52532, 65528, 1278, 54007, 33429, 2502, 50929, 7333, 40073, 51008, 44144, 24895, 1732, 28590, 59879, 21818, 16250, 9032, 33439, 34953, 4787, 26722, 43167, 63311, 28281, 28576, 30876, 14747, 25876, 42288, 26021, 38101, 54760, 65402, 58001, 24366, 1423, 40082, 31100, 15533, 2641, 21074, 52302, 63184, 6990, 57516, 3192, 46758, 1756, 27593, 57031, 25762, 60592, 46739, 39595, 10576, 22314, 26941, 38679, 65276, 18593, 33001, 61174, 22637, 41196, 50209, 41305, 49376, 12824, 62740, 11593, 38252, 19401, 41577, 19078, 28259, 44710, 17633, 47702, 22732, 8660, 40182, 10863, 28218, 26109, 4991, 46581, 44618, 50973, 35711, 36301, 11090, 13596, 14958, 34426, 53672, 23394, 57794, 48226, 46953, 21965, 7764, 63097, 56007, 26795, 56571, 58931, 22444, 32870, 21744, 45557, 59779, 64523, 48744, 20004, 57704, 65052, 22709, 62174, 33524, 63218, 65264, 53276, 44789, 10093, 322, 39024, 46167, 61311, 33889, 45668, 42425, 13429, 42224, 64338, 7286, 45124, 40259, 24632, 51992, 687, 58485, 53566, 31503, 7087, 29663, 38289, 16638, 31885, 50838, 60472, 36807, 54214, 5107, 56122, 60346, 11010, 54230, 55677, 57583, 33891, 39862, 13636, 46408, 26543, 1387, 8799, 25442, 58011, 37024, 60047, 60914, 5688, 38549, 21923, 33213, 29853, 31453, 6671, 54601, 32130, 42269, 30977, 11863, 35455, 10455, 55848, 54500, 9413, 4511, 4488, 25771, 62458, 36447, 17401, 15050, 7266, 9245, 53206, 9085, 56627, 53936, 8965, 36616, 462, 56494, 36587, 49501, 32135, 45247, 61029, 36670, 57324, 22481, 6391, 337, 14853, 54957, 20414, 14720, 32481, 62056, 33356, 22339, 5079, 37595, 14827, 24084, 24979, 49688, 15180, 61334, 48653, 31530, 57702, 23538, 25188, 8478, 51023, 26292, 32784, 30865, 43003, 24506, 60021, 28306, 23541, 26271, 50219, 65080, 56787, 31439, 19094, 29228, 22545, 15960, 12251, 62644, 32722, 7207, 25159, 25474, 33654, 64227, 64004, 37086, 40507, 44278, 32913, 31894, 20612, 44821, 6022, 20784, 58391, 14901, 63411, 64498, 37708, 2650, 6126, 13126, 21417, 7412, 52246, 23865, 15317, 2863, 25078, 295, 7634, 39626, 61272, 13065, 48566, 12956, 97, 58755, 55450, 4376, 11608, 15355, 60838, 25030, 52912, 28561, 24985, 50157, 40354, 17650, 38195, 46127, 54203, 44379, 41992, 39053, 6032, 61943, 46847, 17882, 45373, 40685, 43178, 24832, 37563, 43255, 13215, 33293, 7886, 6916, 59707, 8162, 58541, 30788, 29812, 22270, 27277, 24722, 37026, 21993, 53869, 15306, 16283, 31493, 61281, 1567, 47409, 393, 26532, 50083, 29234, 28146, 16594, 31135, 14959, 18580, 42814, 39285, 60918, 63495, 34234, 5738, 19654, 33934, 44116, 62009, 10165, 2404, 57018, 52767, 50184, 30710, 44419, 26966, 12586, 25617, 51579, 52550, 62988, 58174, 44701, 34138, 47443, 12006, 60495, 46699, 38960, 28445, 41519, 40480, 58907, 37403, 13983, 28926, 15923, 59306, 55281, 36426, 12870, 2853, 8792, 29046, 44184, 14679, 44860, 56488, 49626, 27887, 42318, 64773, 58026, 22160, 44921, 10696, 36527, 23365, 28714, 28763, 43465, 55443, 30708, 9606, 49424, 49259, 62511, 25824, 30400, 35428, 58466, 46151, 1394, 13587, 55960, 38369, 57272, 26961, 13793, 271, 65277, 8937, 42137, 32093, 24913, 35206, 5130, 63572, 32292 }));
        }
    }
}
