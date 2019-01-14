namespace LeetCode.Test
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
            for (var i = 0; i < 1000; i++)
            {
                var idx = solution.PickIndex();
                Assert.IsTrue(idx >= 0 && idx < 2);
                counter[idx]++;
            }

            Assert.IsTrue(counter[0] >= 400 - 50 && counter[0] <= 400 + 50);
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
    }
}
