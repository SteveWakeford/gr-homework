using gr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grTest
{
    [TestClass]
    public class SetFromLinesTest
    {
        [TestMethod]
        public void OneLineBuildsSetWithOneItem()
        {
            var oneLine = "one line";

            var oneLineSet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(oneLine)), s => s);

            Assert.AreEqual(oneLineSet.Count, 1);
        }

        [TestMethod]
        public void TwoLinesBuildsSetWithTwoItems()
        {
            var twoLines = "one line\nanother line";

            var twoLinesSet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(twoLines)), s => s);

            Assert.AreEqual(twoLinesSet.Count, 2);
        }

        [TestMethod]
        public void ThreeLinesBuildsSetWithThreeItems()
        {
            var threeLines = "one line\nanother line\nthird line";

            var threeLinesSet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(threeLines)), s => s);

            Assert.AreEqual(threeLinesSet.Count, 3);
        }

        [TestMethod]
        public void ZeroLinesBuildsSetWithZeroItems()
        {
            string zeroLines = string.Empty;

            var zeroLinesSet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(zeroLines)), s => s);

            Assert.AreEqual(zeroLinesSet.Count, 0);
        }
    }
}
