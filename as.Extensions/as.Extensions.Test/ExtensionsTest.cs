using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace @as.Extensions.Test
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void AssemblyManagerTest()
        {
            new AssemblyManager<string>();
        }

        [TestMethod]
        public void BinaryManagerTest()
        {
            new BinaryManager<string>();
        }

        [TestMethod]
        public void HttpManagerTest()
        {
            new HttpManager<string>();
        }

        [TestMethod]
        public void LocalizableManagerTest()
        {
            DateTime result = DateTime.Now;
            result = "31.12.2015".toUTCDate();
            result = "31.12.2015 04:00".toUTCDate();
            result = "31/12/2015 04:00".toUTCDate();
            result = "31-12-2015 04:00".toUTCDate();
            result = "13.11.15 20:30".toUTCDate();
        }
    }
}
