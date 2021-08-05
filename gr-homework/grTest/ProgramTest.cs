using gr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace grTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        [Ignore]
        public void ProgramMain()
        {
            Program.Main(null);
        }

        [TestMethod]
        public void ParseFileNameDoesNotThrowOnOneArg()
        {
            var oneArg = new string[] { "one" };
            Program.ParseFileName(oneArg);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFileNameThrowsOnNull()
        {
            Program.ParseFileName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFileNameThrowsOnZeroArgs()
        {
            var zeroArgs = new string[] { };
            Program.ParseFileName(zeroArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFileNameThrowsOnTwoArgs()
        {
            var twoArgs = new string[] { "one", "two" };
            Program.ParseFileName(twoArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFileNameThrowsOnThreeArgs()
        {
            var threeArgs = new string[] { "one", "two", "three" };
            Program.ParseFileName(threeArgs);
        }
    }
}
