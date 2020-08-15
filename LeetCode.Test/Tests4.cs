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

        [TestMethod]
        public void TestP398()
        {
            var arr = new int[] { 3, 2, 2, 1 };
            var sln = new P398.Solution(arr);

            Assert.AreEqual(0, sln.Pick(3));
            Assert.AreEqual(3, sln.Pick(1));

            var counter = 0;
            for (var i = 0; i < 100; ++i)
            {
                var pos = sln.Pick(2);
                Assert.IsTrue(pos >= 1 && pos <= 2);
                if (pos == 1) --counter;
                else ++counter;
            }

            Assert.IsTrue(counter >= -20 && counter <= 20);
        }

        [TestMethod]
        public void TestP398S2()
        {
            var arr = new int[] { 3, 2, 2, 1 };
            var sln = new P398.S2.Solution(arr);

            Assert.AreEqual(0, sln.Pick(3));
            Assert.AreEqual(3, sln.Pick(1));

            var counter = 0;
            for (var i = 0; i < 100; ++i)
            {
                var pos = sln.Pick(2);
                Assert.IsTrue(pos >= 1 && pos <= 2);
                if (pos == 1) --counter;
                else ++counter;
            }

            Assert.IsTrue(counter >= -20 && counter <= 20);
        }

    }
}