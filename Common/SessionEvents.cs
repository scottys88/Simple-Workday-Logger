using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Win32;

namespace Common
{
    public class SessionEvents
    {
        public SessionEvents()
        {
        }

        public bool UserSessionStarted(SessionSwitchReason sessionSwitchReason)
        {
            bool userSessionStarted = false;

            if(sessionSwitchReason == SessionSwitchReason.SessionUnlock |
                sessionSwitchReason == SessionSwitchReason.SessionLogon)
            {
                userSessionStarted = true;
            }

            Debug.WriteLine(sessionSwitchReason.ToString());
            Debug.WriteLine($"User session started: {userSessionStarted}");

            return userSessionStarted;
        }
    }
}
