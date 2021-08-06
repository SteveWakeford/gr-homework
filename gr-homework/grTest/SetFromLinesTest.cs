using gr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace grTest
{
    [TestClass]
    public class SetFromLinesTest
    {
        private static Func<string, string> IdentityItemBuilderFunc = s => s;
        private static Func<string, string> NullItemBuilderFunc = s => (string)null;

        [TestMethod]
        public void OneLineBuildsSetWithOneItem()
        {
            var oneLine = "one line";

            var oneLineSet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(oneLine)), IdentityItemBuilderFunc);

            Assert.AreEqual(oneLineSet.Count, 1);
        }

        [TestMethod]
        public void TwoLinesBuildsSetWithTwoItems()
        {
            var twoLines = "one line\nanother line";

            var twoLinesSet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(twoLines)), IdentityItemBuilderFunc);

            Assert.AreEqual(twoLinesSet.Count, 2);
        }

        [TestMethod]
        public void ThreeLinesBuildsSetWithThreeItems()
        {
            var threeLines = "one line\nanother line\nthird line";

            var threeLinesSet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(threeLines)), IdentityItemBuilderFunc);

            Assert.AreEqual(threeLinesSet.Count, 3);
        }

        [TestMethod]
        public void ZeroLinesBuildsSetWithZeroItems()
        {
            string zeroLines = string.Empty;

            var zeroLinesSet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(zeroLines)), IdentityItemBuilderFunc);

            Assert.AreEqual(zeroLinesSet.Count, 0);
        }

        [TestMethod]
        public void NullItemIsNotAddedToSet()
        {
            var oneLine = "one line";

            var emptySet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(oneLine)), NullItemBuilderFunc);

            Assert.AreEqual(emptySet.Count, 0);
        }

        [TestMethod]
        public void SameItemOnlyAddedOnce()
        {
            var triplicated = "one\none\none";

            var oneItemSet = SetFromLines.Build(new MemoryStream(Encoding.ASCII.GetBytes(triplicated)), IdentityItemBuilderFunc);

            Assert.AreEqual(oneItemSet.Count, 1);
            Assert.IsTrue(oneItemSet.Contains("one"));
        }
    }
}
