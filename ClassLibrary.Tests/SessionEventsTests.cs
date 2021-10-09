using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Common.Tests
{
    [TestClass()]
    public class SessionEventsTests
    {
        [TestMethod()]
        public void UserSessionStartedTest_False()
        {
            var sessionEvents = new SessionEvents();
            var sessionSwitchReason = SessionSwitchReason.ConsoleDisconnect;

            var expected = false;

            var actual = sessionEvents.UserSessionStarted(sessionSwitchReason);

            Assert.AreEqual(expected, actual);
        }
    }
}