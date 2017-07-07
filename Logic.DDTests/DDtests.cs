using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.DDTests
{
    [TestClass()]
    public class DDTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\Arguments.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("DDT.Demo.Tests\\Arguments.xml")]
        [TestMethod]
        public void TestNextBiggerNumber()
        {
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);
            int number = Convert.ToInt32(TestContext.DataRow["FirstArg"]);
            long time;
            int actual = ArrayExtensions.NextBiggerNumber(number,out time);

            Assert.AreEqual(expected, actual);

        }


    }
}