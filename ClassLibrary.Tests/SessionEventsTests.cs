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

        [TestMethod()]
        public void UserSessionStartedTest_True()
        {
            var sessionEvents = new SessionEvents();
            var sessionSwitchReasonUnlock = SessionSwitchReason.SessionUnlock;
            var sessionSwitchReasonSessionLogon = SessionSwitchReason.SessionLogon;

            var expected = true;

            var actualResultUnlock = sessionEvents.UserSessionStarted(sessionSwitchReasonUnlock);
            var actualResultLogon = sessionEvents.UserSessionStarted(sessionSwitchReasonSessionLogon);

            Assert.AreEqual(expected, actualResultUnlock);
            Assert.AreEqual(expected, actualResultLogon);
        }
    }
}