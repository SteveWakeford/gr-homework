using gr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace grTest
{
    [TestClass]
    public class ProgramArgsTest
    {
        [TestMethod]
        public void ParseFileNameDoesNotThrowOnOneArg()
        {
            var oneArg = new string[] { "one" };
            ProgramArgs.ParseFileName(oneArg);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFileNameThrowsOnNull()
        {
            ProgramArgs.ParseFileName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFileNameThrowsOnZeroArgs()
        {
            var zeroArgs = new string[] { };
            ProgramArgs.ParseFileName(zeroArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFileNameThrowsOnTwoArgs()
        {
            var twoArgs = new string[] { "one", "two" };
            ProgramArgs.ParseFileName(twoArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFileNameThrowsOnThreeArgs()
        {
            var threeArgs = new string[] { "one", "two", "three" };
            ProgramArgs.ParseFileName(threeArgs);
        }
    }
}
