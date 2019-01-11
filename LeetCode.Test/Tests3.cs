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
    }
}
