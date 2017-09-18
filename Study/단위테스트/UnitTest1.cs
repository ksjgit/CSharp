using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace UnitTestProject1
{
    [TestClass]
    class UnitTest1
    {
        Class1 obj = new Class1();
        [TestMethod]
        public void TestMethod1()
        {
            var r = obj.Met1();
            Assert.AreEqual(0, r);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var r = obj.Met2();
            Assert.AreEqual(0, r);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var r = obj.Met3();
            Assert.AreEqual(0, r);
        }
    }
}
