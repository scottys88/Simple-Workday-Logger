using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Tests
{
    [TestClass()]
    public class WorkDayRepositoryTests
    {
        [TestMethod()]
        public void Retrieve_Pass_Test()
        {
            var workDayRepository = new WorkDayRepository();
            var workDay1 = workDayRepository.CreateWorkday();
            var expected = workDay1.WorkDayId;

            var actual = workDayRepository.Retrieve(expected);

            Assert.AreEqual(expected, actual.WorkDayId);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Retrieve_Fail_Test()
        {
            var workDayRepository = new WorkDayRepository();
            var workDay = workDayRepository.Retrieve("123");

            Assert.AreEqual(workDay.WorkDayId, "123");
        }

        [TestMethod()]
        public void RetrieveAll_EmptyTest()
        {
            var workdayRepository = new WorkDayRepository();
            var expected = 0;

            var actual = workdayRepository.RetrieveAll().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveAll_Test()
        {
            var workdayRepository = new WorkDayRepository();
            var workDay1 = new WorkDay();
            var workDay2 = new WorkDay();
            workdayRepository.WorkDays.Add(workDay1);
            workdayRepository.WorkDays.Add(workDay2);
            var expected = 2;

            var actual = workdayRepository.RetrieveAll().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateWorkday_Fail_Test()
        {
            var workdayRepository = new WorkDayRepository();
            workdayRepository.CreateWorkday();
            workdayRepository.CreateWorkday();
        }

        [TestMethod()]
        public void CreateWorkDay_Success_Test()
        {
            var workdayRepository = new WorkDayRepository();
            var workDay = workdayRepository.CreateWorkday();


            Assert.IsNotNull(workDay);
        }

        [TestMethod()]
        public void GetIsExistingWorkDateTest_NoExistingWorkDays()
        {
            var workdayRepository = new WorkDayRepository();
            var dateToCompare = new DateTimeOffset(DateTime.Now).Date;

            var expected = false;

            var actual = workdayRepository.GetIsExistingWorkDate(dateToCompare);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetIsExistingWorkDateTest_True()
        {
            var workdayRepository = new WorkDayRepository();
            workdayRepository.CreateWorkday();
            var dateToCompare = new DateTimeOffset(DateTime.Now).Date;

            var expected = true;

            var actual = workdayRepository.GetIsExistingWorkDate(dateToCompare);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetIsExistingWorkDateTest_False()
        {
            var workdayRepository = new WorkDayRepository();
            workdayRepository.CreateWorkday();
            var dateToCompare = new DateTimeOffset(DateTime.Now.AddDays(1)).Date;

            var expected = false;

            var actual = workdayRepository.GetIsExistingWorkDate(dateToCompare);

            Assert.AreEqual(expected, actual);
        }
    }
}