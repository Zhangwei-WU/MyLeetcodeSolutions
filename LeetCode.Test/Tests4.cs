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
    }
}