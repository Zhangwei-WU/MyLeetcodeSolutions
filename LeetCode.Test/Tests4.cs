namespace LeetCode.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using LeetCode.Generics;

    public partial class Tests
    {
        [TestMethod]
        public void TestP665()
        {
            var sln = new P665.Solution();
            Assert.IsTrue(sln.CheckPossibility(new int[] { 4, 2, 3 }));
            Assert.IsFalse(sln.CheckPossibility(new int[] { 4, 2, 1 }));
            Assert.IsFalse(sln.CheckPossibility(new int[] { 3, 4, 2, 3 }));
        }

        [TestMethod]
        public void TestP442()
        {
            var sln = new P442.Solution();
            CollectionAssert.AreEquivalent(new int[] { 2, 3 }, sln.FindDuplicates(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }).ToArray());
            CollectionAssert.AreEquivalent(new int[] { 1, 10 }, sln.FindDuplicates(new int[] { 10, 2, 5, 10, 9, 1, 1, 4, 3, 7 }).ToArray());
        }
    }
}