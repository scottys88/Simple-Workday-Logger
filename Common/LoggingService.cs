using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Common
{
    public static class LoggingService
    {
        public static void WriteToFile(List<ILoggable> itemsToLog)
        {
            foreach (var item in itemsToLog)
            {
                Debug.WriteLine(item.Log());
            }
        }
    }
}
