using ClassLibrary;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Common.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod()]
        public void CastToILoggable_ReturnListTest()
        {
            var id = Utility.GenerateID();
            var workDay = new WorkDay(id);
            var list = new List<WorkDay>();
            list.Add(workDay);
            var expected = 1;

            var actual = Utility.CastToILoggable(list);

            Assert.AreEqual(expected, actual.Count);            
        }
    }
}
